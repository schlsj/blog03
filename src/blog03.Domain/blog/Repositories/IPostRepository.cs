using Volo.Abp.Domain.Repositories;

namespace blog03.blog.Repositories
{
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}
