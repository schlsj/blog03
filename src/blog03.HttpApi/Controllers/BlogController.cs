using blog03.blog;
using blog03.ToolKits.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace blog03.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
    public class BlogController : AbpController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        [Route("posts")]
        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync([FromQuery] PagingInput input)
        {
            return await _blogService.QueryPostsAsync(input);
        }

        [HttpGet]
        [Route("post")]
        public async Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url)
        {
            return await _blogService.GetPostDetailAsync(url);
        }

        [HttpGet]
        [Route("posts/category")]
        public async Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByCategoryAsync([Required] string name)
        {
            return await _blogService.QueryPostsByCategoryAsync(name);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync()
        {
            return await _blogService.QueryCategoriesAsync();
        }

        [HttpGet]
        [Route("category")]
        public async Task<ServiceResult<string>> GetCategoryAsync([Required] string name)
        {
            return await _blogService.GetCategoryAsync(name);
        }



        [HttpGet]
        [Route("tags")]
        public async Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync()
        {
            return await _blogService.QueryTagsAsync();
        }

        [HttpPost]
        [Authorize]
        public async Task<ServiceResult<string>> InsertPostAsync([FromBody] PostDto dto)
        {
            try
            {
                return await _blogService.InsertPostAsync(dto);
            }
            catch (Exception ex)
            {
                ServiceResult<string> result = new();
                result.IsFailed("未知异常");
                return result;
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<ServiceResult> DeletePostAsync([Required] int id)
        {
            return await _blogService.DeletePostAsync(id);
        }

        [HttpPut]
        [Authorize]
        public async Task<ServiceResult<string>> UpdatePostAsync([Required] int id, [FromBody] PostDto dto)
        {
            return await _blogService.UpdatePostAsync(id, dto);
        }

        [HttpGet]
        public async Task<ServiceResult<PostDto>> GetPostAsync([Required] int id)
        {
            return await _blogService.GetPostAsync(id);
        }
    }
}
