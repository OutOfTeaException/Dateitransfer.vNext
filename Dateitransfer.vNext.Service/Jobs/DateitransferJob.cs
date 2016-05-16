using log4net;
using Quartz;
using System.Threading;

namespace Dateitransfer.vNext.Service.Jobs
{
    public class DateitransferJob : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DateitransferJob));

        public void Execute(IJobExecutionContext context)
        {
            log.Info($"Führe Job '{context.JobDetail.Key.Name}' aus...");
            Thread.Sleep(2000);
            log.Info($"Job '{context.JobDetail.Key.Name}' ausgeführt.");
        }
    }
}
