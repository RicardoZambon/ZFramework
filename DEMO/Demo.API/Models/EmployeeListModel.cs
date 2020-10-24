using AutoMapper;
using ZFramework.Demo.DAL.BusinessData;

namespace ZFramework.Demo.API.Models
{
    [AutoMap(typeof(Employees))]
    public class EmployeeListModel
    {
        public string FullName { get; set; }

        public bool IsActive { get; set; }
    }
}