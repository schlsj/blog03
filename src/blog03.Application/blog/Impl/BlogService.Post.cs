using blog03.ToolKits.Base;
using blog03.ToolKits.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                 return null;
             });
        }
    }
}
