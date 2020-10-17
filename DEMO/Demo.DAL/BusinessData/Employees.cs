using System.ComponentModel.DataAnnotations;
using ZFramework.Modules.API.BusinessObjects;

namespace ZFramework.Demo.DAL.BusinessData
{
    public class Employees : UserBase
    {
        [StringLength(200)]
        public string FullName { get; set; }
    }
}