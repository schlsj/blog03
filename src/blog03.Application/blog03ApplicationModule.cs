using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace blog03;

[DependsOn(
    typeof(AbpIdentityApplicationModule)
    )]
public class blog03ApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
