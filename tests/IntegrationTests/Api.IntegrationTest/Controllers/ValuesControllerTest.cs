using System;
using System.Threading.Tasks;
using Data;
using Data.Model;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Api.IntegrationTest.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        private TestServer TestServer { get; set; }
        private static MyContext MyContext { get; set; }

        [TestInitialize]
        public void Init()
        {
            TestServer = TestServer.Create<TestStartup>();
            TestServer.BaseAddress = new Uri("http://localhost");
            MyContext = TestStartup.MyContext;
        }

        [TestMethod]
        public async Task Get_WhenValueExists_200()
        {
            //arrange
            MyContext.Values.Add(new Value { Id = 1, Epicness = 1337 });
            await MyContext.SaveChangesAsync();

            //act
            var result = await TestServer.CreateRequest("values/1").GetAsync();

            //assert
            result.EnsureSuccessStatusCode();
            var deserializedResult = JsonConvert.DeserializeObject<Value>(await result.Content.ReadAsStringAsync());
            Assert.AreEqual(1, deserializedResult.Id);
            Assert.AreEqual(1337, deserializedResult.Epicness);

        }
    }
}