using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace blog03.blog.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag, int>
    {
        Task BulkInsertAsync(IEnumerable<PostTag> posts);
    }
}
