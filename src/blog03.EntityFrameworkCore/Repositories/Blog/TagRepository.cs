using blog03.blog;
using blog03.blog.Repositories;
using blog03.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.Repositories.Blog
{
    public class TagRepository : EfCoreRepository<blog03DbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<blog03DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task BulkInsertAsync(IEnumerable<Tag> tags)
        {
            await (await GetDbContextAsync()).Set<Tag>().AddRangeAsync(tags);
            await (await GetDbContextAsync()).SaveChangesAsync();
        }
    }
}
