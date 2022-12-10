using blog03.blog;
using blog03.blog.Repositories;
using blog03.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.Repositories.Blog
{
    public class FriendLinkRepository : EfCoreRepository<blog03DbContext, FriendLink, int>, IFriendLinkRepository
    {
        public FriendLinkRepository(IDbContextProvider<blog03DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
