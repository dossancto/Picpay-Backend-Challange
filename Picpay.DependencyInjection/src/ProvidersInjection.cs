using Picpay.DependencyInjection.Providers;

namespace Picpay.DependencyInjection;

public static class ProvidersInjection
{
    public static IServiceCollection AddProviders(this IServiceCollection services, bool isDev)
    {
        return services
                      .AddUnitOfWork()
                      .AddCryptography(isDev)
                      .AddAuthorizationProvider(isDev)
                      .AddNotifications(isDev)
                      ;
    }
}

