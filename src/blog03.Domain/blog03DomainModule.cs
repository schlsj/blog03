using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace blog03;

[DependsOn(
    typeof(blog03DomainSharedModule),
    typeof(AbpIdentityDomainModule)
)]
public class blog03DomainModule : AbpModule
{
}
