using System;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.IntegrationTest.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        private TestServer TestServer { get; set; }

        [TestInitialize]
        public void Init()
        {
            TestServer = TestServer.Create<TestStartup>();
            TestServer.BaseAddress = new Uri("http://localhost");
        }

        [TestMethod]
        public async Task Get_WhenValueExists_200()
        {
            //arrange
            TestStartup.MyContext.Values.Add(new Value { Id = 1, Epicness = 1337 });
            await TestStartup.MyContext.SaveChangesAsync();

            //act
            var result = await TestServer.CreateRequest("values/1").GetAsync();

            //assert
            result.EnsureSuccessStatusCode();

        }
    }
}
