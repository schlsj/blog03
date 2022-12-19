﻿using blog03.ToolKits.Base;
using blog03.ToolKits.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog03.blog.Impl
{
    public partial class BlogService
    {
        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input)
        {
            return await _blogCacheService.QueryPostsAsync(input, async () =>
             {
                 var result = new ServiceResult<PagedList<QueryPostDto>>();
                 var count = await _postRepository.GetCountAsync();
                 var list = (await _postRepository.GetQueryableAsync()).OrderByDescending(x => x.CreationTime)
                 .PageByIndex(input.Page, input.Limit).Select(x => new PostBriefDto
                 {
                     Title = x.Title,
                     Url = x.Url,
                     Year = x.CreationTime.Year,
                     CreationTime = x.CreationTime.TryToDateTime()
                 }).GroupBy(x => x.Year)
                 .Select(x => new QueryPostDto
                 {
                     Year = x.Key,
                     Posts = x.ToList()
                 }).ToList();
                 result.IsSuccess(new PagedList<QueryPostDto>(count.TryToInt(), list));
                 return result;
             });
        }

        public async Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url)
        {
            return await _blogCacheService.GetPostDetailAsync(url, async () =>
            {
                var result = new ServiceResult<PostDetailDto>();
                var post = await _postRepository.FindAsync(x => x.Url.Equals(url));
                if (null == post)
                {
                    result.IsFailed(ResponseText.WHAT_NOT_EXIST.Format("URL", url));
                    return result;
                }
                var category = await _categoryRepository.GetAsync(post.CategoryId);
                var tags = from post_tags in await _postTagRepository.GetListAsync()
                           join tag in await _tagRepository.GetListAsync()
                           on post_tags.TagId equals tag.Id
                           where post_tags.PostId.Equals(post.Id)
                           select new TagDto
                           {
                               TagName = tag.TagName,
                               DisplayName = tag.DisplayName,
                           };
                var previous = (await _postRepository.GetQueryableAsync())
                .Where(x => x.CreationTime > post.CreationTime).Take(1).FirstOrDefault(); ;
                var next = (await _postRepository.GetQueryableAsync()).Where(x => x.CreationTime < post.CreationTime)
.OrderByDescending(x => x.CreationTime).Take(1).FirstOrDefault();
                var postDetail = new PostDetailDto
                {
                    Title = post.Title,
                    Author = post.Author,
                    Url = post.Url,
                    Html = post.Html,
                    Markdown = post.Markdown,
                    CreationTime = post.CreationTime.TryToDateTime(),
                    Category = new CategoryDto
                    {
                        CategoryName = category.CategoryName,
                        DisplayName = category.DisplayName,
                    },
                    Tags = tags,
                    Previous = previous == null ? null : new PostForPagedDto
                    {
                        Title = previous.Title,
                        Url = previous.Url,
                    },
                    Next = next == null ? null : new PostForPagedDto
                    {
                        Title = next.Title,
                        Url = next.Url,
                    },
                };
                result.IsSuccess(postDetail);
                return result;
            });
        }

        public async Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByCategoryAsync(string name)
        {
            return await _blogCacheService.QueryPostsByCategoryAsync(name, async () =>
             {
                 var result = new ServiceResult<IEnumerable<QueryPostDto>>();
                 var list = (from posts in await _postRepository.GetListAsync()
                             join categories in await _categoryRepository.GetListAsync()
                             on posts.CategoryId equals categories.Id
                             where categories.DisplayName.Equals(name)
                             orderby posts.CreationTime descending
                             select new PostBriefDto
                             {
                                 Title = posts.Title,
                                 Url = posts.Url,
                                 Year = posts.CreationTime.Year,
                                 CreationTime = posts.CreationTime.TryToDateTime()
                             }).GroupBy(x => x.Year).Select(x => new QueryPostDto
                             {
                                 Year = x.Key,
                                 Posts = x.ToList()
                             });
                 result.IsSuccess(list);
                 return result;
             });
        }
    }
}
