using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZFramework.Demo.DAL.BusinessData;
using ZFramework.Demo.DAL.Repositories;
using ZFramework.Modules.API.Controllers;
using ZFramework.Modules.API.Models;
using ZFramework.Modules.API.Services;

namespace ZFramework.Demo.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : AccountControllerBase<IEmployeeRepository, Employees, LoginModel>
    {
        public AccountController(IEmployeeRepository userRepository, ITokenService tokenService) : base(userRepository, tokenService)
        {
        }

        [HttpPost, Route(nameof(Authenticate))]
        public new async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginModel model)
            => await base.Authenticate(model);
    }
}