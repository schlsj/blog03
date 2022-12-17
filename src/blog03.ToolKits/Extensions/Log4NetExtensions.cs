using log4net;
using log4net.Config;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace blog03.ToolKits.Extensions
{
    public static class Log4NetExtensions
    {
        public static void UseLog4Net()
        {
            var log4netRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(log4netRepository, new FileInfo("log4net.config"));
        }
    }
}