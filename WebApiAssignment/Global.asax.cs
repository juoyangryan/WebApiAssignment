using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using DomainLayer.Interfaces;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories;
using ServiceLayer.Services;

namespace WebApiAssignment
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ////Autofac
            //var builder = new ContainerBuilder();
            //builder.RegisterType<ApplicationContext>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<QuoteRepository>().As<IQuoteRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            //builder.RegisterType<QuoteService>().As<IQuoteService>().InstancePerLifetimeScope();

            //var container = builder.Build();
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
