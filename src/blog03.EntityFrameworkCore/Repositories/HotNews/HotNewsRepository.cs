using blog03.EntityFrameworkCore;
using blog03.HotNews.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.Repositories.HotNews
{
    public class HotNewsRepository : EfCoreRepository<blog03DbContext, blog03.HotNews.HotNews, Guid>, IHotNewsRepository
    {
        public HotNewsRepository(IDbContextProvider<blog03DbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<blog03.HotNews.HotNews> hotNews)
        {
            await DbContext.Set<blog03.HotNews.HotNews>().AddRangeAsync(hotNews);
            await DbContext.SaveChangesAsync();
        }
    }
}
