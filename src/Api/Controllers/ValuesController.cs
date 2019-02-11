using System.Threading.Tasks;
using System.Web.Http;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers
{

    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        private readonly MyContext _myContext;

        public ValuesController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Value> GetValue(int id)
        {
            var value = _myContext.Values.FirstOrDefaultAsync().Result;
            return value;
        }  
    }
}
