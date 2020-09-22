using ZFramework.Data.Abstract.Interfaces;
using ZFramework.Data.EfCore.Attributes;

namespace ZFramework.Demo.DAL.BusinessData.Queries
{
    [Query("some_view_name")]
    public class EmployeeViewQuery : IEntity
    {
        public string Username { get; set; }
    }
}