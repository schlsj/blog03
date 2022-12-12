using Volo.Abp.Modularity;

namespace blog03.ToolKits
{
    [DependsOn(
        typeof(blog03DomainModule)
        )]
    public class blog03ToolKitsModule : AbpModule
    {
    }
}
