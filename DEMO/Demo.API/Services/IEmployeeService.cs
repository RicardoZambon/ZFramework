using ZFramework.Data.Abstract.Services;
using ZFramework.Demo.API.Models;

namespace ZFramework.Demo.API.Services
{
    public interface IEmployeeService : IListService<EmployeeListModel>, IModifyDataService<EmployeeEditModel>, IDeleteService
    {
    }
}