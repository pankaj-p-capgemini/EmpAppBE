using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EmpAppBE.ActionFilters;

namespace EmpAppBE
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Enabling Cross-Origin Requests (CORS) for WebAPIs
            config.EnableCors();

            // Registering Action Filter (LoggingFilterAttribute) for NLog
            config.Filters.Add(new LoggingFilterAttribute());
            config.Filters.Add(new GlobalExceptionAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
