using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //[HttpGet(Name ="message")]
        [HttpGet]
        [Route("welcome")]
        public string Index()
        {
            return "Welcome to web";
        }

        [HttpGet]
        [Route("data/{name?}")]

        //public string GetData(string? name){return "Welcome to web " + name;}

        public string GetData([FromRoute(Name = "name")] string? x)
        {
            return "Welcome to web " + (x ?? "NA");
        }
    }
}
