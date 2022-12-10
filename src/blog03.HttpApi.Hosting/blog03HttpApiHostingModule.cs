using blog03.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace blog03.Web;

[DependsOn(
    typeof(blog03SwaggerModule),
    typeof(blog03HttpApiModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
    )]
public class blog03HttpApiHostingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        //Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = false;
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        //app.UseStaticFiles();
        app.UseRouting();
        app.UseConfiguredEndpoints();
    }
}
