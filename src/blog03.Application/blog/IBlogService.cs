using blog03.ToolKits.Base;
using System.Threading.Tasks;

namespace blog03.blog
{
    public partial interface IBlogService
    {
        Task<ServiceResult<string>> InsertPostAsync(PostDto dto);
        Task<ServiceResult> DeletePostAsync(int id);
        Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto);
        Task<ServiceResult<PostDto>> GetPostAsync(int id);
    }
}
