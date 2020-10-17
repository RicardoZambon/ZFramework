using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ZFramework.Demo.API.Services;
using ZFramework.Demo.DAL.BusinessData;

namespace ZFramework.Demo.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet, Route(nameof(List))]
        public ActionResult<IQueryable<Employees>> List()
        {
            var user = User.Identity.Name;

            return Ok(employeeService.List());
        }
    }
}