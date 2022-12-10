using Microsoft.Extensions.Configuration;
using System.IO;

namespace blog03.Configurations
{
    public class AppSettings
    {
        private static readonly IConfigurationRoot _config;

        static AppSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _config = builder.Build();
        }

        public static string EnableDb => _config["ConnectionStrings:Enable"];
        public static string ConnectionStrings => _config.GetConnectionString(EnableDb);
        public static string ApiVersion => _config["ApiVersion"];
    }
}
