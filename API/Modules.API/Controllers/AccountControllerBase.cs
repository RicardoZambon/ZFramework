using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZFramework.Modules.API.Models;
using ZFramework.Modules.API.Services;

namespace ZFramework.Modules.API.Controllers
{
    public abstract class AccountControllerBase<TAccountService, TLoginModel> : ControllerBase where TAccountService : class, IAccountService where TLoginModel : LoginModel
    {
        private readonly TAccountService AccountService;

        public AccountControllerBase(TAccountService accountService)
        {
            AccountService = accountService;
        }


        [HttpPost, Route(nameof(Authenticate)), AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] TLoginModel model)
        {
            if (AccountService.AuthenticateAndGenerateToken(model, out var token))
            {
                return new { model.Username, token };
            }
            return Unauthorized();
        }
    }

    public abstract class AccountControllerBase<TLoginModel> : AccountControllerBase<IAccountService, TLoginModel> where TLoginModel : LoginModel
    {
        protected AccountControllerBase(IAccountService accountService) : base(accountService)
        {
        }
    }

    public abstract class AccountControllerBase : AccountControllerBase<LoginModel>
    {
        protected AccountControllerBase(IAccountService accountService) : base(accountService)
        {
        }
    }
}