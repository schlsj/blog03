using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace blog03;

[DependsOn(
    typeof(AbpIdentityDomainSharedModule)
    )]
public class blog03DomainSharedModule : AbpModule
{
}
