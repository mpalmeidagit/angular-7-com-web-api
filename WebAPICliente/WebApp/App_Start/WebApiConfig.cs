using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Habilita o CORS
            var cors = new EnableCorsAttribute("*", "*", "*");//origins,headers,metods
            config.EnableCors(cors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Força o reposnse no formato JSON
            var formato = GlobalConfiguration.Configuration.Formatters;
            formato.Remove(formato.XmlFormatter);
        }
    }
}
