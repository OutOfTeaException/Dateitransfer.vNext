using Dateitransfer.vNext.Lib.Service;
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateitransfer.vNext.Service.Jobs
{
    public class JobScheduler
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        private JobService jobService;
        private IScheduler jobScheduler;

        public JobScheduler(JobService jobService, IScheduler scheduler)
        {
            this.jobService = jobService;
            this.jobScheduler = scheduler;
        }

        public void StartJobs()
        {
            // 1. Jobs aus DB laden
            // 2. Quartz Jobs erstellen
            // 3. Quartz JObs starten
            log.Info("Starte Jobs...");
            
            try
            {
                log.Debug("Lade Jobs aus Datenbank...");
                var jobs = jobService.GetAllJobs().Where(j => j.IsEnabled);
                log.Debug("Jobs aus Datenbank geladen.");
                    
                foreach (var job in jobs)
                {
                    log.Debug($"Erstelle Job {job.Name}...");
                    
                    IJobDetail quartzJob = JobBuilder.Create<DateitransferJob>()
                       .WithIdentity($"{job.Id} - {job.Name}", "group1")
                       .UsingJobData("Id", job.Id)
                       .Build();

                    ITrigger trigger = TriggerBuilder.Create()
                       .WithIdentity($"{job.Id} - {job.Name}", "group1")
                       .StartNow()
                       .WithCronSchedule(job.Cron)
                       .Build();

                    jobScheduler.ScheduleJob(quartzJob, trigger);
                    log.Info($"Job {job.Name} erstellt.");
                }

                jobScheduler.Start();
            }
            catch (Exception ex)
            {
                log.Error("Die Jobs konnten nicht gestartet werden!", ex);
            }
        }

        public void StopJobs()
        {
            jobScheduler.Shutdown(true);
        }
    }
}
