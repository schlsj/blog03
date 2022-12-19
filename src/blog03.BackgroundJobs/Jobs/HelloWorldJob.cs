using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace blog03.BackgroundJobs.Jobs
{
    public class HelloWorldJob : BackgroundService
    {
        private readonly ILogger<HelloWorldJob> _log;

        public HelloWorldJob(ILogger<HelloWorldJob> log)
        {
            _log = log;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var msg = $"CurrentTime:{DateTime.Now}, Hello World";
                Console.WriteLine(msg);
                _log.LogInformation(msg);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
