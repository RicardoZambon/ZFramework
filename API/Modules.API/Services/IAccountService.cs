using System.Threading.Tasks;
using ZFramework.Modules.API.Models;

namespace ZFramework.Modules.API.Services
{
    public interface IAccountService
    {
        bool AuthenticateAndGenerateToken(LoginModel model, out string token);
    }
}