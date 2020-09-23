using System.Collections.Generic;
using System.Linq;
using ZFramework.Modules.API.Models;

namespace ZFramework.Modules.API.Repositories
{
    public static class UserRepository
    {
        public static UserModel Get(string username, string password)
        {
            var users = new List<UserModel>();
            users.Add(new UserModel { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new UserModel { Id = 2, Username = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}