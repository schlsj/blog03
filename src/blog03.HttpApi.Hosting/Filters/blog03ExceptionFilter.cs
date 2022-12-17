using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace blog03.Web.Filters
{
    public class blog03ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<blog03ExceptionFilter> _log;

        public blog03ExceptionFilter(ILogger<blog03ExceptionFilter> log)
        {
            _log = log;
        }

        public void OnException(ExceptionContext context)
        {
            _log.LogError(context.Exception, $"{context.HttpContext.Request.Path}|{context.Exception.Message}");
        }
    }
}
