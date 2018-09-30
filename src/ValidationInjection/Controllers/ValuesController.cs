using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidationInjection.Models;

namespace ValidationInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> Post(ValuesModel value)
        {
            return Task.FromResult<IActionResult>(Accepted());
        }
    }
}
