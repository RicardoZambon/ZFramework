using ZFramework.Data.Abstract.Entities;
using ZFramework.Modules.API.BusinessObjects;

namespace ZFramework.Demo.DAL.BusinessData
{
    public class Employees : UserBase
    {
        public string Username { get; set; }

        public bool IsActive { get; set; }
    }
}