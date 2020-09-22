using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
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
            var migrationsAssembly = Assembly.Load(RelationalOptionsExtension.Extract(options).MigrationsAssembly);

            modelBuilder.CreateEntitiesModel(migrationsAssembly);

            modelBuilder.ApplyConfigurationsFromAssembly(migrationsAssembly);
        }
    }
}