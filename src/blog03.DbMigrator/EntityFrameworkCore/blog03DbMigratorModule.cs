using blog03.DbMigrator.EntityFrameworkCore;
using blog03.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace blog03.DbMigrator;

[DependsOn(
    typeof(blog03EntityFrameworkCoreModule)
    )]
public class blog03DbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<blog03DbMigratorDbContext>();
    }
}
