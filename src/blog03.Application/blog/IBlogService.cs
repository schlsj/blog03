using System.Threading.Tasks;

namespace blog03.blog
{
    public interface IBlogService
    {
        Task<bool> InsertPostAsync(PostDto dto);
        Task<bool> DeletePostAsync(int id);
        Task<bool> UpdatePostAsync(int id, PostDto dto);
        Task<PostDto> GetPostAsync(int id);
    }
}
