using AutoMapper;
using Dateitransfer.vNext.Service.Jobs;
using log4net;
using log4net.Core;
using Ninject;
using System;

namespace Dateitransfer.vNext.Service
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            //TODO: Aus app.config laden
            const int webApiPort = 12345;
            log.Info("Starte Anwendung...");
            
            string webApiBaseAddress = $"http://localhost:{webApiPort}";
            log.Info($"Starte WebApi auf Port {webApiPort}...");

            var kernel = Bootstrap.DateitransferKernel.CreateKernel();

            // Start WebApi host 
            using (Microsoft.Owin.Hosting.WebApp.Start(webApiBaseAddress, (appBuilder) =>
            {
                // Hier wird der WebApi Krams und der IoC Container initialisiert
                new Bootstrap.StartupWebApi().Configuration(appBuilder, () => kernel);
            }))
            {
                log.InfoFormat("WebApi gestartet.");
                JobScheduler jobScheduler = kernel.Get<JobScheduler>();
                jobScheduler.StartJobs();


                log.Info("Anwendung gestartet.");
                Console.ReadLine();
                log.Info("Beende Anwendung...");
                log.Info("Beende Jobs...");
                jobScheduler.StopJobs();
                log.Info("Jobs beendet");
                log.Info("Beende WepApi...");
            }

            log.Info("WebApi beendet.");

            log.Info("Anwendung beendet.");
        }
    }
}
