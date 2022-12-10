using blog03.blog;
using blog03.blog.Repositories;
using blog03.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.Repositories.Blog
{
    public class CategoryRepository : EfCoreRepository<blog03DbContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<blog03DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
