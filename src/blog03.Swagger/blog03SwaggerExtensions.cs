using blog03.Configurations;
using blog03.Swagger.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace blog03.Swagger
{
    public static class blog03SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "blog03.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "blog03.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "blog03.Application.Contracts.xml"));
                options.DocumentFilter<SwaggerDocumentFilter>();
                var security = new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，请输入Bearer {Token}进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                };
                options.AddSecurityDefinition("JWT", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });
                options.DefaultModelExpandDepth(-1);
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
                options.RoutePrefix = String.Empty;
                options.DocumentTitle = "接口文档-sch";
            });
        }

        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>
        {
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v1,
                Name="博客前台接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="sch-博客前台接口",
                    Description=description,
                },
            },
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v2,
                Name="博客后台接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="sch-博客后台接口",
                    Description=description,
                },
            },
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v3,
                Name="通用公共接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="sch-通用公共接口",
                    Description=description,
                },
            },
            new SwaggerApiInfo
            {
                UrlPrefix=Grouping.GroupName_v4,
                Name="JWT授权接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="sch-JWT授权接口",
                    Description=description,
                },
            },
        };

        private static readonly string version = "1.0.0";
        private static readonly string description = "接口描述文档-swagger";

        internal class SwaggerApiInfo
        {
            public string UrlPrefix { get; set; }
            public string Name { get; set; }
            public OpenApiInfo OpenApiInfo { get; set; }
        }
    }
}
