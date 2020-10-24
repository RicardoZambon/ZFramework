using System.Linq;
using System.Threading.Tasks;
using ZFramework.Demo.API.Models;

namespace ZFramework.Demo.API.Services
{
    public interface IEmployeeService //: IListService<EmployeeListModel>, IModifyDataService<EmployeeEditModel>, IDeleteService
    {
        IQueryable<EmployeeListModel> List();

        Task UpdateAsync(EmployeeEditModel model);
    }
}