using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ZFramework.Data.EfCore.ExtensionMethods
{
    public static class ServiceExtension
    {
        private const string DefaultMigrationTableName = "MigrationsHistory";
        private const string DefaultMigrationSchema = "EF";


        public static void AddFrameworkEfCoreDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString) where TDBContext : ZDbContext
        {
            services.AddFrameworkEfCoreDatabase<TDBContext>(connectionString, typeof(TDBContext).Assembly.GetName().Name, DefaultMigrationTableName, DefaultMigrationSchema);
        }

        public static void AddFrameworkEfCoreDatabase(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName)
        {
            services.AddFrameworkEfCoreDatabase<ZDbContext>(connectionString, migrationsAssemblyName, DefaultMigrationTableName, DefaultMigrationSchema);
        }

        public static void AddFrameworkEfCoreDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString, string migrationsTableName, string migrationsSchema) where TDBContext : ZDbContext
        {
            services.AddFrameworkEfCoreDatabase<TDBContext>(connectionString, typeof(TDBContext).GetType().Assembly.GetName().Name, migrationsTableName, migrationsSchema);
        }

        public static void AddFrameworkEfCoreDatabase(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName, string migrationsTableName, string migrationsSchema)
        {
            services.AddFrameworkEfCoreDatabase<ZDbContext>(connectionString, migrationsAssemblyName, migrationsTableName, migrationsSchema);
        }

        private static void AddFrameworkEfCoreDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName, string migrationsTableName, string migrationsSchema) where TDBContext : ZDbContext
        {
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();

            services.AddDbContextPool<TDBContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(
                    connectionString,
                    b =>
                        b.MigrationsAssembly(migrationsAssemblyName)
                        .MigrationsHistoryTable(migrationsTableName, migrationsSchema)
                );
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });
        }
    }
}