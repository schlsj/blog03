using blog03.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace blog03.EntityFrameworkCore;

[DependsOn(
    typeof(blog03DomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
public class blog03EntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<blog03DbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        Configure<AbpDbContextOptions>(options =>
        {
            switch (AppSettings.EnableDb)
            {
                case "MySQL":
                    options.UseMySQL();
                    break;
                case "SqlServer":
                    options.UseSqlServer();
                    break;
                default:
                    options.UseMySQL();
                    break;
            }
        });
    }
}
