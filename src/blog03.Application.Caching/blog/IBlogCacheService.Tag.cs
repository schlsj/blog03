using blog03.blog;
using blog03.ToolKits.Base;

namespace blog03.Application.Caching.blog
{
    public partial interface IBlogCacheService
    {
        Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync(Func<Task<ServiceResult<IEnumerable<QueryTagDto>>>> factory);
    }
}
