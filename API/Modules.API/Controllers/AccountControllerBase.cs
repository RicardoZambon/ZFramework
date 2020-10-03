using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZFramework.Data.Abstract.Interfaces;
using ZFramework.Modules.API.Interfaces;
using ZFramework.Modules.API.Models;
using ZFramework.Modules.API.Repositories;
using ZFramework.Modules.API.Services;

namespace ZFramework.Modules.API.Controllers
{
    public abstract class AccountControllerBase<TRepository, TUser, TLoginModel> : ControllerBase where TRepository : class, IUserRepository<TUser> where TUser : class, IEntity, IUser where TLoginModel : LoginModel
    {
        private readonly TRepository UserRepository;
        private readonly ITokenService TokenService;

        public AccountControllerBase(TRepository userRepository, ITokenService tokenService)
        {
            UserRepository = userRepository;
            TokenService = tokenService;
        }


        protected async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginModel model)
        {
            if (UserRepository.Authenticate(model.Username, model.Password))
            {
                var token = TokenService.GenerateToken(model.Username);
                return new { model.Username, token };
            }
            return Unauthorized();
        }
    }
}