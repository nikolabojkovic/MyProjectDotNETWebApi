using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyProjectWebApiDotNET.App_Start
{
    public static class WebApiConfig
    {
        private const string _localhost = "localhost";

        public static void Register(HttpConfiguration config)
        {
            // TODO: Add any additional configuration code.

            // allowing acces to front end
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name : "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        public static string DbConnectionString {
            get
            {
                if (HttpContext.Current.Request.Url.Host == _localhost)
                    return ConfigurationManager.ConnectionStrings["localhostDbConnectionString"].ConnectionString;

                return ConfigurationManager.ConnectionStrings["remotehostDbConnectionString"].ConnectionString;
            }

            private set { }
        }
    }
}