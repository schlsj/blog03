using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace blog03.Application.Caching
{
    [DependsOn(
        typeof(blog03DomainSharedModule),
        typeof(AbpCachingModule)
        )]
    public class blog03ApplicationCachingModule:AbpModule
    {
    }
}
