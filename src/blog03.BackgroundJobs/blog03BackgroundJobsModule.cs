using blog03.Configurations;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MySql.Core;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace blog03.BackgroundJobs
{
    [DependsOn(
        typeof(AbpBackgroundJobsHangfireModule)
        )]
    public class blog03BackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(new MySqlStorage(AppSettings.ConnectionStrings,
                    new MySqlStorageOptions
                    {
                        //TablePrefix = blog03Consts.DbTablePrefix + "hangfire"
                    }));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var builder = context.GetApplicationBuilder();
            builder.UseHangfireServer();
            builder.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl=false,
                        SslRedirect=false,
                        LoginCaseSensitive=true,
                        Users = new[]
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login=AppSettings.Hangfire.Login,
                                PasswordClear=AppSettings.Hangfire.Password,
                            }
                        }
                    })
                },
                DashboardTitle = "任务调度中心"
            });
            var serviceProvider = context.ServiceProvider;
            serviceProvider.UseHangfireTest();
            serviceProvider.UseWallpaperJob();
            serviceProvider.UseHotNewsJob();
        }
    }
}
