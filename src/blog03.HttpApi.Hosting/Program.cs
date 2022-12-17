using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace blog03.Web;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Logging.AddLog4Net("log4net.config");
            builder.Logging.AddLog4Net();
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac();
            await builder.AddApplicationAsync<blog03HttpApiHostingModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            return 1;
        }
        finally
        {
        }
    }
}
