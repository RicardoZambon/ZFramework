using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using ZFramework.Modules.API.Services;
using ZFramework.Modules.API.Services.Handlers;

namespace ZFramework.Modules.API.ExtensionMethods
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddTokenService(this IServiceCollection services, [NotNull] Action<TokenOptions> options)
            => services.AddTokenService<TokenService>(options);

        public static IServiceCollection AddTokenService<TTokenService>(this IServiceCollection services, [NotNull] Action<TokenOptions> options) where TTokenService : TokenService
        {
            services.AddScoped<ITokenService, TTokenService>();
            services.Configure(options);
            return services;
        }
    }
}