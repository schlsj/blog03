using blog03.blog;
using blog03.ToolKits.Base;
using blog03.ToolKits.Extensions;

namespace blog03.Application.Caching.blog.Impl
{
    public partial class BlogCacheService
    {
        private const string KEY_QueryPosts = "Blog:Post:QueryPosts-{0}-{1}";

        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input, Func<Task<ServiceResult<PagedList<QueryPostDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_QueryPosts.FormatWith(input.Page, input.Limit), factory, CacheStrategy.ONE_DAY);
        }
    }
}
