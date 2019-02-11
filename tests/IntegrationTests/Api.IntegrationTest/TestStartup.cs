using Data;
using Microsoft.EntityFrameworkCore;

namespace Api.IntegrationTest
{
    public class TestStartup : Startup
    {
        public static MyContext MyContext { get; set; }

        protected override void Bootstrap()
        {
            var options = new DbContextOptionsBuilder<MyContext>();
            options.UseInMemoryDatabase("MyDatabase");
        }
    }
}