using Microsoft.Extensions.DependencyInjection;
using Picpay.Infra.Providers.Authorization;
using Picpay.Adapters.Authorization;

namespace Picpay.DependencyInjection.Providers;

internal static class AutorizationInjection
{
    public static IServiceCollection AddAuthorizationProvider(this IServiceCollection services, bool isDev)
    {
        return services.AddScoped<IPaymentAuthorization, MockPaymentAuthorization>();
    }
}
