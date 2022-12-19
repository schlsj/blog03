using blog03.ToolKits.Base;
using System.Threading.Tasks;

namespace blog03.blog
{
    public partial interface IBlogService
    {
        Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input);

        Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url);
    }
}
