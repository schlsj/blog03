using blog03.ToolKits.Helper;
using Microsoft.AspNetCore.Mvc.Filters;

namespace blog03.Web.Filters
{
    public class blog03ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LoggerHelper.WriteToFile($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
