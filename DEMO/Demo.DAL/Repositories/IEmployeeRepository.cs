using ZFramework.Data.Abstract.Repositories;
using ZFramework.Demo.DAL.BusinessData;

namespace ZFramework.Demo.DAL.Repositories
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
    }
}