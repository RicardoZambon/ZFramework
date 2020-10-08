using ZFramework.Data.Abstract.Attributes;
using ZFramework.Demo.DAL.BusinessData;
using ZFramework.Demo.DAL.Repositories;
using ZFramework.Modules.API.Services;
using ZFramework.Modules.API.Services.Handlers;

namespace ZFramework.Demo.DAL.Services.Handlers
{
    [DataService(typeof(IAccountService))]
    public class DefaultAccountService : AccountServiceBase<IEmployeeRepository, Employees>
    {
        public DefaultAccountService(IEmployeeRepository userRepository, ITokenService tokenService) : base(userRepository, tokenService)
        {
        }
    }
}