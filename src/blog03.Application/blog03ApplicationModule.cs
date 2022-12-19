using blog03.Application.Caching;
using blog03.EntityFrameworkCore;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace blog03;

[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(blog03EntityFrameworkCoreModule),
    typeof(blog03DomainSharedModule),
    typeof(blog03DomainModule),
    typeof(blog03ApplicationCachingModule),
    typeof(blog03ApplicationContractsModule),
    typeof(AbpIdentityApplicationModule)
    )]
public class blog03ApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<blog03ApplicationModule>(validate: true);
            options.AddMaps<blog03AutoMapperProfile>(validate: true);
        });
    }
}
