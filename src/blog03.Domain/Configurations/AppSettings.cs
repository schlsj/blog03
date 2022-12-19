using Microsoft.Extensions.Configuration;
using System;
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

        public static class GitHub
        {
            public static int UserId => Convert.ToInt32(_config["Github:UserId"]);
            public static string Client_ID => _config["Github:ClientID"];
            public static string Client_Secret => _config["Github:ClientSecret"];
            public static string Redirect_Uri => _config["Github:RedirectUri"];
            public static string ApplicationName => _config["Github:ApplicationName"];
        }

        public static class JWT
        {
            public static string Domain => _config["JWT:Domain"];
            public static string SecurityKey => _config["JWT:SecurityKey"];
            public static int Expires => Convert.ToInt32(_config["JWT:Expires"]);
        }

        public static class Caching
        {
            public static string RedisConnectionString => _config["Caching:RedisConnectionString"];
        }

        public static class Hangfire
        {
            public static string Login => _config["Hangfire:Login"];
            public static string Password => _config["Hangfire:Password"];
        }
    }
}
