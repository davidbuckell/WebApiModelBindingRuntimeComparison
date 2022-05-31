using Microsoft.AspNetCore.Mvc;

namespace dotnetcore31.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StravaTest : Controller
    {
        [HttpPost]
        public IActionResult Index([FromBody]StravaEventData data)
        {
            return Ok(data.Updates.Type);
        }
    }
}