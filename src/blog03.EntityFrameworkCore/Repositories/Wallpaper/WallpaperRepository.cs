using blog03.EntityFrameworkCore;
using blog03.Wallpaper.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.Repositories.Wallpaper
{
    public class WallpaperRepository : EfCoreRepository<blog03DbContext, blog03.Wallpaper.Wallpaper, Guid>, IWallpaperRepository
    {
        public WallpaperRepository(IDbContextProvider<blog03DbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task BulkInsertAsync(IEnumerable<blog03.Wallpaper.Wallpaper> wallpapers)
        {
            await DbContext.Set<blog03.Wallpaper.Wallpaper>().AddRangeAsync(wallpapers);
            await DbContext.SaveChangesAsync();
        }
    }
}
