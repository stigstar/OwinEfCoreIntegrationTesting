using System.Web.Http;
using Api.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Api.Startup))]

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

            var container = Bootstrap();
            var httpDependencyResolver = new WindsorDependencyResolver(container);
            config.DependencyResolver = httpDependencyResolver;
        }

        protected virtual IWindsorContainer Bootstrap()
        {
            var continer = new WindsorContainer();
            continer.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
            var options = new DbContextOptionsBuilder<MyContext>().UseSqlServer("MyConnection").Options;
            continer.Register(Component.For<MyContext>().UsingFactoryMethod(c => new MyContext(options)).LifestyleTransient());
            return continer;
        }
    }
}