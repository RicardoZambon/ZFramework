using Microsoft.EntityFrameworkCore;

namespace ZFramework.Data.EfCore
{
    public class ZDbContext : DbContext
    {
        public ZDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}