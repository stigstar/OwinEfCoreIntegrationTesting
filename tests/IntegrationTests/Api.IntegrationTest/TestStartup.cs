using Microsoft.EntityFrameworkCore;

namespace Api.IntegrationTest
{
    public class TestStartup : Startup
    {
        public static MyContect MyContect { get; set; }

        protected override void Bootstrap()
        {
            var options = DbContextOptionsBuilder<MyContect>();
            options.UseInMemory
        }
    }
}