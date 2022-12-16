using blog03.Configurations;
using blog03.Swagger;
using blog03.ToolKits.Base;
using blog03.ToolKits.Extensions;
using blog03.Web.Filters;
using blog03.Web.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
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
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30),
                    ValidateIssuerSigningKey = true,
                    ValidAudience = AppSettings.JWT.Domain,
                    ValidIssuer = AppSettings.JWT.Domain,
                    IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes()),
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                      {
                          context.HandleResponse();
                          context.Response.ContentType = "application/json;charset=utf-8";
                          context.Response.StatusCode = StatusCodes.Status200OK;
                          var result = new ServiceResult();
                          result.IsFailed("UnAuthorized");
                          await context.Response.WriteAsync(result.ToJson());
  
                      }
                };
            });
        context.Services.AddAuthentication();
        context.Services.AddHttpClient();
        Configure<MvcOptions>(options =>
        {
            var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute &&
                  attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));
            options.Filters.Remove(filterMetadata);
            options.Filters.Add(typeof(blog03ExceptionFilter));
        });
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
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseConfiguredEndpoints();
    }
}
