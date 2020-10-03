using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ZFramework.Data.EfCore.ExtensionMethods
{
    public static class ServiceExtension
    {
        private const string DefaultMigrationTableName = "MigrationsHistory";
        private const string DefaultMigrationSchema = "EF";


        public static void AddFrameworkEfCoreSqlServerDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString) where TDBContext : ZDbContext
        {
            services.AddFrameworkEfCoreSqlServerDatabase<TDBContext>(connectionString, typeof(TDBContext).Assembly.GetName().Name, DefaultMigrationTableName, DefaultMigrationSchema);
        }

        public static void AddFrameworkEfCoreSqlServerDatabase(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName)
        {
            services.AddFrameworkEfCoreSqlServerDatabase<ZDbContext>(connectionString, migrationsAssemblyName, DefaultMigrationTableName, DefaultMigrationSchema);
        }

        public static void AddFrameworkEfCoreSqlServerDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString, string migrationsTableName, string migrationsSchema) where TDBContext : ZDbContext
        {
            services.AddFrameworkEfCoreSqlServerDatabase<TDBContext>(connectionString, typeof(TDBContext).GetType().Assembly.GetName().Name, migrationsTableName, migrationsSchema);
        }

        public static void AddFrameworkEfCoreSqlServerDatabase(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName, string migrationsTableName, string migrationsSchema)
        {
            services.AddFrameworkEfCoreSqlServerDatabase<ZDbContext>(connectionString, migrationsAssemblyName, migrationsTableName, migrationsSchema);
        }

        private static void AddFrameworkEfCoreSqlServerDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName, string migrationsTableName, string migrationsSchema) where TDBContext : ZDbContext
        {
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();

            services.AddDbContextPool<ZDbContext, TDBContext>((serviceProvider, optionsBuilder) =>
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


        public static void AddFrameworkEfCoreSqliteDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString) where TDBContext : ZDbContext
        {
            services.AddFrameworkEfCoreSqliteDatabase<TDBContext>(connectionString, typeof(TDBContext).Assembly.GetName().Name, DefaultMigrationTableName);
        }

        public static void AddFrameworkEfCoreSqliteDatabase(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName)
        {
            services.AddFrameworkEfCoreSqliteDatabase<ZDbContext>(connectionString, migrationsAssemblyName, DefaultMigrationTableName);
        }

        public static void AddFrameworkEfCoreSqliteDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString, string migrationsTableName) where TDBContext : ZDbContext
        {
            services.AddFrameworkEfCoreSqliteDatabase<TDBContext>(connectionString, typeof(TDBContext).GetType().Assembly.GetName().Name, migrationsTableName);
        }

        public static void AddFrameworkEfCoreSqliteDatabase(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName, string migrationsTableName)
        {
            services.AddFrameworkEfCoreSqliteDatabase<ZDbContext>(connectionString, migrationsAssemblyName, migrationsTableName);
        }

        private static void AddFrameworkEfCoreSqliteDatabase<TDBContext>(this IServiceCollection services, [NotNull] string connectionString, string migrationsAssemblyName, string migrationsTableName) where TDBContext : ZDbContext
        {
            services.AddEntityFrameworkSqlite();
            services.AddEntityFrameworkProxies();

            services.AddDbContextPool<ZDbContext, TDBContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlite(
                    connectionString,
                    b =>
                        b.MigrationsAssembly(migrationsAssemblyName)
                        .MigrationsHistoryTable(migrationsTableName)
                );
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });
        }
    }
}