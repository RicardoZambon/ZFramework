using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> AuthenticateAsync(string username, string password)
            => await DbContext.Set<Employees>().AnyAsync(x => x.IsActive && x.Username == username && x.PasswordHash == password);
    }
}