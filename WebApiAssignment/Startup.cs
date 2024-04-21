using Autofac;
using Autofac.Integration.WebApi;
using DomainLayer.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories;
using ServiceLayer.Services;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiAssignment.AuthenticationProvider;

[assembly: OwinStartup(typeof(WebApiAssignment.Startup))]

namespace WebApiAssignment
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Configure Autofac
            var builder = new ContainerBuilder();

            //register controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //autofac
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As< IUserRepository > ().InstancePerLifetimeScope();
            builder.RegisterType<QuoteRepository>().As< IQuoteRepository > ().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As< IUserService > ().InstancePerLifetimeScope();
            builder.RegisterType<QuoteService>().As< IQuoteService > ().InstancePerLifetimeScope();

            // Register AuthProvider
            builder.RegisterType<AuthProvider>().InstancePerLifetimeScope();

            // Build the Autofac container
            var container = builder.Build();

            // Set up Web API
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            // Set up Autofac Web API dependency resolver
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var myProvider = container.Resolve<AuthProvider>(); // Resolve AuthProvider

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = myProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
