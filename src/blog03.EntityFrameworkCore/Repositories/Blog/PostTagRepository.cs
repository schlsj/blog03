using blog03.blog;
using blog03.blog.Repositories;
using blog03.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.Repositories.Blog
{
    public class PostTagRepository : EfCoreRepository<blog03DbContext, PostTag, int>, IPostTagRepository
    {
        public PostTagRepository(IDbContextProvider<blog03DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task BulkInsertAsync(IEnumerable<PostTag> postTags)
        {
            await (await GetDbContextAsync()).Set<PostTag>().AddRangeAsync(postTags);
            await (await GetDbContextAsync()).SaveChangesAsync();
        }
    }
}
