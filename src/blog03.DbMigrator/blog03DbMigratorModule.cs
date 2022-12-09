using blog03.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace blog03.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(blog03EntityFrameworkCoreModule),
    typeof(blog03ApplicationContractsModule)
    )]
public class blog03DbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
