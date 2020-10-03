using ZFramework.Data.Abstract.Entities;
using ZFramework.Modules.API.Interfaces;

namespace ZFramework.Modules.API.BusinessObjects
{
    public abstract class UserBase : DbEntity, IUser
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}