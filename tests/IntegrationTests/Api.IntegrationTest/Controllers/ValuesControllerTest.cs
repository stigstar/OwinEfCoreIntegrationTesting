using System;
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
        public void Get_WhenValueExists_200()
        {
            //arrange


            //act
            var result = TestServer.CreateRequest("values/1");

            //assert
        }
    }
}
