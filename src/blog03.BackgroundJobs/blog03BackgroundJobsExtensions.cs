using blog03.BackgroundJobs.Jobs.Hangfire;
using blog03.BackgroundJobs.Jobs.HotNews;
using blog03.BackgroundJobs.Jobs.Wallpaper;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace blog03.BackgroundJobs
{
    public static class blog03BackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider serviceProvider)
        {
            var job = serviceProvider.GetService<HangfireTestJob>();
            RecurringJob.AddOrUpdate("定时任务测试0", () => job.ExecuteAsync(), CronType.Minute(2));
        }

        public static void UseWallpaperJob(this IServiceProvider serviceProvider)
        {
            var job = serviceProvider.GetService<WallpaperJob>();
            RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 3));
        }

        public static void UseHotNewsJob(this IServiceProvider serviceProvider)
        {
            var job = serviceProvider.GetService<HostNewsJob>();
            RecurringJob.AddOrUpdate("每日热点数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 2));
        }
    }
}
