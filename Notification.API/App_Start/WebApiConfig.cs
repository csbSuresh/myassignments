using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Notification.API.Helpers;
using Notification.API.Repositories;
using Notification.API.Services;
using SimpleInjector;
using Unity;
using Unity.Lifetime;

namespace Notification.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ICompany, CompanyDetails>(new HierarchicalLifetimeManager());
            container.RegisterType<ISchedule, ScheduleDetails>(new HierarchicalLifetimeManager()); ;
            container.RegisterType<INotification, NotificationDetails>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

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
