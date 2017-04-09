using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Tracker.Wildlife.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            // Add CORS Support
            //EnableCorsAttribute CorsAttribute = new EnableCorsAttribute("*", "*", "GET,POST,PUT,PATCH,DELETE");
            //config.EnableCors(CorsAttribute);
            config.EnsureInitialized();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
