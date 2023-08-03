using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudAndAngular.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEmptyController : ControllerBase
    {
        [HttpGet("BasesEmpty")]
        public IActionResult GetBasesEmpty()
        {
            return Ok("Hello world!");
        }
    }
}
