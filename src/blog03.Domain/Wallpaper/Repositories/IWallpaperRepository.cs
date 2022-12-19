using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace blog03.Wallpaper.Repositories
{
    public interface IWallpaperRepository:IRepository<Wallpaper,Guid>
    {
        Task BulkInsertAsync(IEnumerable<Wallpaper> wallpapers);
    }
}
