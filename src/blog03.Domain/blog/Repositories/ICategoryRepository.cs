using Volo.Abp.Domain.Repositories;

namespace blog03.blog.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
