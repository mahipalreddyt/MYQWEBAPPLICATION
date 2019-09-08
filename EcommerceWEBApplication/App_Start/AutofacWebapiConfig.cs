using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL.Interfaces;
using BAL.Factory;
using Autofac.Integration.Mvc;

namespace EcommerceWEBApplication.App_Start
{
    public class AutofacWebapiConfig
    {
        public static void ConfigureDI()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<UserManagentServiceFactory>().As<IUserManagentServiceFactory>();
            builder.RegisterType<CategoryManagementServiceFactory>().As<ICategoryManagementServiceFactory>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }



    }
}