using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace blog03.blog.Repositories
{
    public interface ITagRepository:IRepository<Tag,int>
    {
        Task BulkInsertAsync(IEnumerable<Tag> tags);
    }
}
