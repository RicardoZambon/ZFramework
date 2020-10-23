using Microsoft.EntityFrameworkCore;
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


        public async Task<bool> AuthenticateAsync(long userId, string passwordHash)
            => await DbContext.Set<Employees>().AnyAsync(x => x.ID == userId && x.IsActive && x.PasswordHash == passwordHash);

        public async Task<Employees> FindByUsernameAsync(string username)
            => await DbContext.Set<Employees>().FirstOrDefaultAsync(x => x.Username == username);
    }
}