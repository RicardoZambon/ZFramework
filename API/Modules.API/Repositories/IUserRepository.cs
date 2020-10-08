using ZFramework.Data.Abstract.Interfaces;
using ZFramework.Data.Abstract.Repositories;
using ZFramework.Modules.API.Interfaces;

namespace ZFramework.Modules.API.Repositories
{
    public interface IUserRepository<TUser> : IRepository<TUser> where TUser : class, IEntity, IUserAccount
    {
        bool Authenticate(string username, string password);
    }
}