using blog03.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace blog03.DbMigrator.EntityFrameworkCore
{
    public class blog03DbMigratorDbContext:AbpDbContext<blog03DbMigratorDbContext>
    {
        public blog03DbMigratorDbContext(DbContextOptions<blog03DbMigratorDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure();
        }
    }
}
