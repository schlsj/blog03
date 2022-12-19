using blog03.blog;
using blog03.ToolKits.Base;

namespace blog03.Application.Caching.blog
{
    public partial interface IBlogCacheService
    {
        Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync(Func<Task<ServiceResult<IEnumerable<QueryCategoryDto>>>> factory);
        Task<ServiceResult<string>> GetCategoryAsync(string name, Func<Task<ServiceResult<string>>> factory);
    }
}
