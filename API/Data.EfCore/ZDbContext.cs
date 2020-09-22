using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ZFramework.Data.EfCore.ExtensionMethods;

namespace ZFramework.Data.EfCore
{
    public class ZDbContext : DbContext
    {
        public ZDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var options = this.GetService<IDbContextOptions>();

            modelBuilder.CreateEntitiesModel(options);
            //CreateQueriesModel
        }
    }
}