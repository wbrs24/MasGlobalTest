using AppDataAccess.Interfaces;
using AppDataAccess.Repositories;
using AppServices.Factory;
using AppServices.Interfaces;
using AppServices.Services;
using AppUtilities;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MasGlobalTest.Controllers;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MasGlobalTest.App_Start
{
    public class DIConfig
    {

        public static IContainer Container { get; set; }
        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);
            RegisterRepositories(builder);
            RegisterControllers(builder);
            RegisterOthers(builder);

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EmployeeFactory>().As<IEmployeeFactory>().SingleInstance();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }

        private static void RegisterOthers(ContainerBuilder builder)
        {
            builder.RegisterType<Utilities>().As<IUtilities>().SingleInstance();
        }
    }
}