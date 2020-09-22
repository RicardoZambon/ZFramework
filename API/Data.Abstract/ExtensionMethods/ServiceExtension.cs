using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZFramework.Data.Abstract.Attributes;

namespace ZFramework.Data.Abstract.ExtensionMethods
{
    public static class ServiceExtension
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            var repositoryTypes = TypeExtension.GetReferencedTypes<RepositoryAttribute>();
            foreach (var repositoryType in repositoryTypes)
            {
                if (repositoryType.GetCustomAttribute<RepositoryAttribute>() is RepositoryAttribute repository)
                {
                    services.AddScoped(repository.ServiceType, repositoryType);
                }
            }
        }

        public static void AddDataServices(this IServiceCollection services)
        {
            var dataServiceTypes = TypeExtension.GetReferencedTypes<DataServiceAttribute>();
            foreach (var dataServiceType in dataServiceTypes)
            {
                if (dataServiceType.GetCustomAttribute<DataServiceAttribute>() is DataServiceAttribute dataService)
                {
                    services.AddScoped(dataService.ServiceType, dataServiceType);
                }
            }
        }
    }
}