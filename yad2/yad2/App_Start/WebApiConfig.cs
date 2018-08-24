using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace yad2.App_Start
{
    public class WebApiConfig : Controller
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ProductApi",
                routeTemplate: "api/products/{id}",
                defaults: new { controller = "ProductApi", action = "GetProduct" },
                constraints: new { id = "[0-9]+" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "PhotoTitleApi",
            //    routeTemplate: "api/photos/{title}",
            //    defaults: new { controller = "PhotoApi", action = "GetPhotoByTitle" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "PhotosApi",
            //    routeTemplate: "api/photos",
            //    defaults: new { controller = "PhotoApi", action = "GetAllPhotos" }
            //);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}