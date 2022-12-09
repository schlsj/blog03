using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace blog03;

[DependsOn(
    typeof(blog03ApplicationModule),
    typeof(AbpIdentityHttpApiModule)
    )]
public class blog03HttpApiModule : AbpModule
{
}
