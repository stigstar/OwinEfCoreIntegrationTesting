using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Api.IntegrationTest
{
    public class TestStartup : Startup
    {
        public static MyContext MyContext { get; set; }

        protected override IWindsorContainer Bootstrap()
        {
            var continer = new WindsorContainer();
            continer.Register(Classes.FromThisAssembly().BasedOn<ApiController>());
            var options = new DbContextOptionsBuilder<MyContext>().UseInMemoryDatabase("MyConnection").Options;
            continer.Register(Component.For<MyContext>().UsingFactoryMethod(c => new MyContext(options)));
            MyContext = continer.Resolve<MyContext>();
            return continer;
        }
    }
}