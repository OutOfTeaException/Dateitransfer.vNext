using AutoMapper;
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

            // Start WebApi host 
            using (Microsoft.Owin.Hosting.WebApp.Start(webApiBaseAddress, (appBuilder) =>
            {
                // Hier wird der WebApi Krams und der IoC Container initialisiert
                new Bootstrap.StartupWebApi().Configuration(appBuilder, Bootstrap.DateitransferKernel.CreateKernel);
            }))
            {
                log.InfoFormat("WebApi gestartet.");
                log.Info("Anwendung gestartet.");
                Console.ReadLine();
                log.Info("Beende Anwendung...");
            }

            log.Info("Anwendung beendet.");
        }
    }
}
