using Microsoft.AspNetCore.Mvc;
using ZFramework.Data.EfCore;

namespace ZFramework.Demo.API.Controllers
{
    public class TestController : ControllerBase
    {
        public TestController(ZDbContext dbContext)
        {

        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}