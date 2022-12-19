using Volo.Abp.DependencyInjection;

namespace blog03.BackgroundJobs.Jobs
{
    public interface IBackgroundJob:ITransientDependency
    {
        Task ExecuteAsync();
    }
}
