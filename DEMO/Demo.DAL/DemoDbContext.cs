using Microsoft.EntityFrameworkCore;
using ZFramework.Data.EfCore;

namespace ZFramework.Demo.DAL
{
    public class DemoDbContext : ZDbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}