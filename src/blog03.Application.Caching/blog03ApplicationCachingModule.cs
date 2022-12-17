using blog03.Configurations;
using blog03.ToolKits;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace blog03.Application.Caching
{
    [DependsOn(
        typeof(blog03ToolKitsModule),
        typeof(blog03ApplicationContractsModule),
        typeof(blog03DomainModule),
        typeof(blog03DomainSharedModule),
        typeof(AbpCachingModule)
        )]
    public class blog03ApplicationCachingModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
            });
        }
    }
}
