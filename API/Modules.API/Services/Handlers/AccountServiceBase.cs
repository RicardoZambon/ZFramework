using ZFramework.Data.Abstract.Interfaces;
using ZFramework.Modules.API.Interfaces;
using ZFramework.Modules.API.Models;
using ZFramework.Modules.API.Repositories;

namespace ZFramework.Modules.API.Services.Handlers
{
    public abstract class AccountServiceBase<TUserRepository, TUser> : IAccountService where TUserRepository : class, IUserRepository<TUser> where TUser : class, IEntity, IUserAccount
    {
        private readonly TUserRepository UserRepository;
        private readonly ITokenService TokenService;

        public AccountServiceBase(TUserRepository userRepository, ITokenService tokenService)
        {
            UserRepository = userRepository;
            TokenService = tokenService;
        }

        public virtual bool AuthenticateAndGenerateToken(LoginModel model, out string token)
        {
            if (UserRepository.Authenticate(model.Username, model.Password))
            {
                token = TokenService.GenerateToken(model.Username);
                return true;
            }
            token = null;
            return false;
        }
    }
}