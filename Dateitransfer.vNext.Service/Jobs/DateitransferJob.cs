using System;
using System.Threading;
using log4net;
using Quartz;
using Dateitransfer.vNext.Lib.Service;

namespace Dateitransfer.vNext.Service.Jobs
{
    [DisallowConcurrentExecution]
    public class DateitransferJob : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DateitransferJob));

        private JobService jobService;

        public DateitransferJob(JobService jobService)
        {
            this.jobService = jobService;
        }

        public void Execute(IJobExecutionContext context)
        {
            log.Info($"Führe Job '{context.JobDetail.Key.Name}' aus...");

            try
            {
                int jobId = (int)context.MergedJobDataMap["Id"];

                var job = jobService.GetJob(jobId);
                

                Thread.Sleep(2000);

                job.LastRun = DateTime.Now;

                jobService.SaveChanges();

                log.Info($"Job '{context.JobDetail.Key.Name}' ausgeführt.");
            }
            catch (Exception ex)
            {
                log.Error($"Fehler bei der Ausfüherung von Job '{context.JobDetail.Key.Name}'!", ex);
                throw new JobExecutionException($"Fehler bei der Ausfüherung von Job '{context.JobDetail.Key.Name}'!", ex);
            }
        }
    }
}
