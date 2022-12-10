using blog03.blog;
using blog03.blog.Repositories;
using blog03.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.Repositories.Blog
{
    public class PostRepository : EfCoreRepository<blog03DbContext, Post, int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<blog03DbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
