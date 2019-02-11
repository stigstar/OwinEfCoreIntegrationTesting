using Data;
using Microsoft.EntityFrameworkCore;

namespace Api.IntegrationTest
{
    public class TestStartup : Startup
    {
        public static MyContext MyContext { get; set; }

        protected override void Bootstrap()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MyContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase("MyDatabase");
            MyContext = new MyContext(dbContextOptionsBuilder.Options);
        }
    }
}