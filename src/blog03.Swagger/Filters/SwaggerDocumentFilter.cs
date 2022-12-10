using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog03.Swagger.Filters
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var tags = new List<OpenApiTag>
            {
                new OpenApiTag
                {
                    Name="Blog",
                    Description="个人博客相关接口",
                    ExternalDocs=new OpenApiExternalDocs{Description="包含：文章/标签/分类/友链"},
                },
                new OpenApiTag
                {
                    Name="HelloWorld",
                    Description="通用公共接口",
                    ExternalDocs=new OpenApiExternalDocs{Description="这里是一些通用的公共接口"},
                },
            };
            swaggerDoc.Tags = tags.OrderBy(x => x.Name).ToList();
        }
    }
}
