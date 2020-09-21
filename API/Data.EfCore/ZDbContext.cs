using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Reflection;
using ZFramework.Data.Abstract.ExtensionMethods;
using ZFramework.Data.Abstract.Interfaces;

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
            var migrationsAssembly = RelationalOptionsExtension.Extract(options).MigrationsAssembly;

            EntitiesFromAssembly(modelBuilder, Assembly.Load(migrationsAssembly));
        }

        public /*static*/ ModelBuilder EntitiesFromAssembly(/*this*/ ModelBuilder modelBuilder, Assembly assembly, Func<Type, bool> predicate = null)
        {
            //var entityMethod = typeof(ModelBuilder).GetMethods().Single(e => e.Name == "Entity" && e.ContainsGenericParameters && e.GetParameters().Length == 0);
            //var configureMethod = typeof(IConfigurableEntity).GetMethod(nameof(IConfigurableEntity.Configure));
            //var modelBuildingMethod = typeof(IConfigurableEntity).GetMethod(nameof(IConfigurableEntity.OnModelBuilding));

            foreach (var entityType in assembly.GetReferencedConstructibleTypes(typeof(IEntity)))
            {
                if (entityType.GetConstructor(Type.EmptyTypes) == null || (!predicate?.Invoke(entityType) ?? false))
                {
                    continue;
                }

                //var typeBuilder = entityMethod.MakeGenericMethod(entityType).Invoke(modelBuilder, null);
                //if (entityType.ImplementsInterface<IConfigurableEntity>())
                //{
                    modelBuilder.ApplyConfiguration()

                //    var instance = Activator.CreateInstance(entityType);
                //    configureMethod.Invoke(instance, new[] { typeBuilder });

                //    modelBuildingMethod.Invoke(instance, new[] { modelBuilder });
                //}

                modelBuilder.Entity(entityType);

                //typeof(ModelBuilderExtension).GetMethod(nameof(InitializeEntity)).MakeGenericMethod(entityType).Invoke(null, new[] { assembly, typeBuilder });
            }
            return modelBuilder;
        }
    }
}