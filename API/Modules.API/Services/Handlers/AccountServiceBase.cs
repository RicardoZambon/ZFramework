using ZFramework.Data.Abstract.Entities;
using ZFramework.Modules.API.Interfaces;
using ZFramework.Modules.API.Models;
using ZFramework.Modules.API.Repositories;
using ZFramework.Modules.API.Security;

namespace ZFramework.Modules.API.Services.Handlers
{
    public abstract class AccountServiceBase<TUserRepository, TUser> : IAccountService where TUserRepository : class, IUserRepository<TUser> where TUser : BaseEntity, IUserAccount
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
            if (UserRepository.FindByUsernameAsync(model.Username).Result is TUser user
                && UserRepository.AuthenticateAsync(user.ID, PasswordHash.Create(user.ID, model.Password)).Result)
            {
                token = TokenService.GenerateToken(model.Username);
                return true;
            }
            token = null;
            return false;
        }
    }
}