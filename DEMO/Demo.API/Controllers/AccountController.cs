using Microsoft.AspNetCore.Mvc;
using ZFramework.Modules.API.Controllers;
using ZFramework.Modules.API.Services;

namespace ZFramework.Demo.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : AccountControllerBase
    {
        public AccountController(IAccountService accountService) : base(accountService)
        {
        }
    }
}