using AutoMapper;
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
        static void Main(string[] args)
        {
            string webApiBaseAddress = "http://localhost:12345/";
            
            // Start WebApi host 
            using (Microsoft.Owin.Hosting.WebApp.Start<StartupWebApi>(url: webApiBaseAddress))
            {
                Console.WriteLine("WebApi gestartet.");
                Console.ReadLine();
            }
        }
    }
}
