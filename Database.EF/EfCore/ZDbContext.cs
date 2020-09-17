using Microsoft.EntityFrameworkCore;

namespace ZFramework.Data.Db.EfCore
{
    public class ZDbContext : DbContext
    {
        public ZDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}