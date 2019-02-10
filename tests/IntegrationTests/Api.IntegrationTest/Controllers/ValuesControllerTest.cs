using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.IntegrationTest.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestInitialize]
        public void Init()
        {
            TestServer = TestServer.Create<TestStartup>()
        }

        [TestMethod]
        public void Get_WhenValueExists_200()
        {
            //arrange


            //act
            var result = Test

            //assert
        }
    }
}
