using System.Threading.Tasks;
using ZFramework.Data.Abstract.Interfaces;
using ZFramework.Modules.API.Interfaces;

namespace ZFramework.Modules.API.Repositories
{
    public interface IUserRepository<TUser> where TUser : class, IEntity, IUserAccount
    {
        Task<bool> AuthenticateAsync(long userId, string passwordHash);

        Task<TUser> FindByUsernameAsync(string username);
    }
}