using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.App_Start
{
    public class IoCConfig
    {
        internal static void ConfigureResolver()
        {
            IContainer container = InitializeContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer InitializeContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<Services.UserRepository>().As<Services.IUserRepository>();
            //tymczasowe rozwiazanie,
            //TODO: trzeba zrobic zeby moduly pobieral przez assembly
            builder.RegisterModule(new Services.InstallModule());
            builder.RegisterModule(new DAL.UnitOfWork.InstallModule());
            builder.RegisterModule(new DAL.InstallModule());
            return builder.Build();
        }
    }
}