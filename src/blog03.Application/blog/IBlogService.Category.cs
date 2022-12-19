using blog03.ToolKits.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blog03.blog
{
    public partial interface IBlogService
    {
        Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync();
        Task<ServiceResult<string>> GetCategoryAsync(string name);
    }
}
