using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ZFramework.Demo.API.Models;
using ZFramework.Demo.API.Services;

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
        public ActionResult<IQueryable<EmployeeListModel>> List()
        {
            return Ok(employeeService.List());
        }

        [HttpPost, Route(nameof(Update))]
        public async Task<IActionResult> Update(EmployeeEditModel model)
        {
            await employeeService.UpdateAsync(model);
            return Ok();
        }
    }
}