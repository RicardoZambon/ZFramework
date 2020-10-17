using System.ComponentModel.DataAnnotations;
using ZFramework.Data.Abstract.Entities;
using ZFramework.Modules.API.Interfaces;

namespace ZFramework.Modules.API.BusinessObjects
{
    public abstract class UserBase : DbEntity, IUserAccount
    {
        [StringLength(100)]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}