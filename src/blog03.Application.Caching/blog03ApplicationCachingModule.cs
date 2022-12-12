using blog03.ToolKits;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace blog03.Application.Caching
{
    [DependsOn(
        typeof(blog03ToolKitsModule),
        typeof(blog03ApplicationContractsModule),
        typeof(blog03DomainSharedModule),
        typeof(AbpCachingModule)
        )]
    public class blog03ApplicationCachingModule:AbpModule
    {
    }
}
