using System.Linq;
using ZFramework.Data.Abstract.Attributes;
using ZFramework.Data.EfCore;
using ZFramework.Data.EfCore.Repositories;
using ZFramework.Demo.DAL.BusinessData;

namespace ZFramework.Demo.DAL.Repositories.EfCore
{
    [Repository(typeof(IEmployeeRepository))]
    public class EmployeeRepository : EfRepository<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(ZDbContext dbContext) : base(dbContext)
        {
        }

        public bool Authenticate(string username, string password)
            => DbContext.Set<Employees>().Any(x => x.IsActive && x.Username == username && x.PasswordHash == password);
    }
}