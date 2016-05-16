using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Web.Http;

namespace Dateitransfer.vNext.Service.Bootstrap
{
    public class StartupWebApi
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder, Func<IKernel> kernel)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // WebApi soll Ninject nutzen
            appBuilder.UseNinjectMiddleware(kernel)
                      .UseNinjectWebApi(config);
        }
    }
}
