using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ZFramework.Data.Abstract.Attributes;
using ZFramework.Data.EfCore;
using ZFramework.Demo.DAL.BusinessData;

namespace ZFramework.Demo.DAL.Repositories.EfCore
{
    [Repository(typeof(IEmployeeRepository))]
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ZDbContext DbContext;

        public EmployeeRepository(ZDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public async Task<bool> AuthenticateAsync(long userId, string passwordHash)
            => await DbContext.Set<Employees>().AnyAsync(x => x.ID == userId && x.IsActive && x.PasswordHash == passwordHash);

        public async Task DeleteAync(params object[] keyValues)
        {
            var entity = await FindByKeyAsync(keyValues);
            if (entity != null)
            {
                entity.IsDeleted = true;
                Update(entity);
            }
        }

        public async Task<Employees> FindByKeyAsync(params object[] keyValues)
            => await DbContext.Set<Employees>().FindAsync(keyValues);

        public async Task<Employees> FindByUsernameAsync(string username)
            => await DbContext.Set<Employees>().FirstOrDefaultAsync(x => x.Username == username);

        public async Task InsertAsync(Employees entity)
            => await DbContext.Set<Employees>().AddAsync(entity);

        public IQueryable<Employees> List()
            => DbContext.Set<Employees>().AsQueryable();

        public void Update(Employees entity)
            => DbContext.Set<Employees>().Update(entity);
    }
}