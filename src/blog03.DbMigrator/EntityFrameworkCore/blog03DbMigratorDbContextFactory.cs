using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace blog03.DbMigrator.EntityFrameworkCore
{
    public class blog03DbMigratorDbContextFactory:IDesignTimeDbContextFactory<blog03DbMigratorDbContext>
    {
        public blog03DbMigratorDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            string connctionString = configuration.GetConnectionString("Default");
            var builder = new DbContextOptionsBuilder<blog03DbMigratorDbContext>()
                .UseMySql(connctionString,ServerVersion.AutoDetect(connctionString));
            return new blog03DbMigratorDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
