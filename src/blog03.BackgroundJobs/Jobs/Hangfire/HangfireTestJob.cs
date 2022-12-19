using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog03.BackgroundJobs.Jobs.Hangfire
{
    public class HangfireTestJob : IBackgroundJob
    {
        private readonly ILogger<HangfireTestJob> _logger;

        public HangfireTestJob(ILogger<HangfireTestJob> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteAsync()
        {
            Console.WriteLine("定时任务测试");
            _logger.LogInformation("定时任务测试");
            await Task.CompletedTask;
        }
    }
}
