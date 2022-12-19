using blog03.blog;
using blog03.ToolKits.Base;

namespace blog03.Application.Caching.blog
{
    public partial interface IBlogCacheService
    {
        Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input, Func<Task<ServiceResult<PagedList<QueryPostDto>>>> factory);
    }
}
