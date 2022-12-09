using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace blog03.Swagger
{
    public static class blog03SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "title占位",
                    Version = "1.0.0",
                    Description = "接口swagger文档",
                });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "blog03.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "blog03.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "blog03.Application.Contracts.xml"));
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "默认接口");
            });
        }
    }
}
