using ZFramework.Data.Abstract.Repositories;
using ZFramework.Demo.DAL.BusinessData;
using ZFramework.Modules.API.Repositories;

namespace ZFramework.Demo.DAL.Repositories
{
    public interface IEmployeeRepository : IRepository<Employees>, IUserRepository<Employees>
    {
    }
}