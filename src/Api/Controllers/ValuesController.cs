using System;
using System.Threading.Tasks;
using System.Web.Http;
using Data;
using Microsoft.Owin;
namespace Api.Controllers
{
    public class ValuesController : ApiController
    {
        private MyContext _myContext;

        public ValuesController()
        {
            _myContext = new MyContext();
        }

        public IHttpActionResult GetValues(int foo) 
        {
            _myContext
        }  
    }
}
