using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly MyContext _myContext;

        public ValuesController()
        {
            _myContext = new MyContext();
        }

        public async Task<Value> GetValue(int id)
        {
            var value = await _myContext.Values.FirstOrDefaultAsync(x => x.Id == id);
            return value;
        }  
    }
}
