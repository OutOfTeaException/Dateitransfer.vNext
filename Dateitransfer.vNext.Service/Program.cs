using AutoMapper;
using log4net;
using log4net.Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dateitransfer.vNext.Service
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            const int webApiPort = 12345;
            log.Info("Starte Anwendung...");
            
            string webApiBaseAddress = $"http://localhost:{webApiPort}";
            log.Info($"Starte WebApi auf Port {webApiPort}...");

            // Start WebApi host 
            using (Microsoft.Owin.Hosting.WebApp.Start<StartupWebApi>(url: webApiBaseAddress))
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
