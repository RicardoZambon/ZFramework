using ZFramework.Data.Abstract.Entities;

namespace ZFramework.Demo.DAL.BusinessData
{
    public class Employees : DbEntity
    {
        public string Username { get; set; }

        public string IsActive { get; set; }
    }
}