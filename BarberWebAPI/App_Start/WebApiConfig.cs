using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BarberWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(); 
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetPhotoApi",
                routeTemplate: "api/GetPhoto/{id}",
                defaults: new { controller = "Barbers", action = "GetImage" }
            );

            config.Routes.MapHttpRoute(
                name: "PostBookingApi",
                routeTemplate: "api/PostBooking/{controller}/{action}",
                defaults: new { controller = "Bookings", action = "PostBooking" }
            );
            config.Routes.MapHttpRoute(
                name: "GetBarberByName",
                routeTemplate: "api/GetBarberByName/{controller}/{action}/{Name}",
                defaults: new { controller = "Barbers", action = "GetBarberByName", Name=RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "BarbersApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Barbers", action = "GetBarbers", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DaysApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Days", action = "GetDaysByBarberID", id = RouteParameter.Optional }
            );
        }
    }
}
