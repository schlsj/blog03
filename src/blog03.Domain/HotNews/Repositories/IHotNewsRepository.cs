using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace blog03.HotNews.Repositories
{
    public interface IHotNewsRepository : IRepository<HotNews, Guid>
    {
        Task BulkInsertAsync(IEnumerable<HotNews> hotNews);
    }
}
