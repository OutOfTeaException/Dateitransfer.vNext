using Dateitransfer.vNext.Service.Jobs;
using log4net;
using Ninject;
using System;

namespace Dateitransfer.vNext.Service
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            IKernel ioc = null;
            JobScheduler jobScheduler = null;
            IDisposable webApi = null;

            //TODO: Aus app.config laden
            const int webApiPort = 12345;
            log.Info("Starte Anwendung...");

            try
            {
                // Ioc Container initialisieren
                ioc = Bootstrap.DateitransferKernel.CreateKernel();
                
                // Start WebApi host 
                string webApiBaseAddress = $"http://localhost:{webApiPort}";
                log.Info($"Starte WebApi auf Port {webApiPort}...");

                webApi = Microsoft.Owin.Hosting.WebApp.Start(webApiBaseAddress, (appBuilder) =>
                {
                    // Hier wird der WebApi Krams initialisiert
                    new Bootstrap.StartupWebApi().Configuration(appBuilder, () => ioc);
                });

                log.InfoFormat("WebApi gestartet.");

                log.Info("Starte Job Scheduler...");
                jobScheduler = ioc.Get<JobScheduler>();
                jobScheduler.StartJobs();
                log.Info("Job Scheduler gestartet.");

                log.Info("Anwendung gestartet.");
                Console.ReadLine();
                log.Info("Beende Anwendung...");
            }
            finally
            {
                // TODO: Ggfs. in try...catch Blöcke packen
                log.Info("Beende Jobs...");
                jobScheduler?.StopJobs();
                log.Info("Jobs beendet");

                log.Info("Beende WepApi...");
                webApi?.Dispose();
                log.Info("WebApi beendet.");

                ioc?.Dispose();
            }

            log.Info("Anwendung beendet.");
        }
    }
}
