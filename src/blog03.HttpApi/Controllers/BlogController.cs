using blog03.blog;
using blog03.ToolKits.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace blog03.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : AbpController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
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
        public async Task<ServiceResult> DeletePostAsync([Required] int id)
        {
            return await _blogService.DeletePostAsync(id);
        }

        [HttpPut]
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
