using System.Linq;
using System.Threading.Tasks;
using ZFramework.Demo.DAL.BusinessData;
using ZFramework.Modules.API.Repositories;

namespace ZFramework.Demo.DAL.Repositories
{
    public interface IEmployeeRepository : IUserRepository<Employees>
    {
        Task DeleteAync(params object[] keyValues);

        Task<Employees> FindByKeyAsync(params object[] keyValues);

        Task InsertAsync(Employees entity);

        IQueryable<Employees> List();

        void Update(Employees entity);
    }
}