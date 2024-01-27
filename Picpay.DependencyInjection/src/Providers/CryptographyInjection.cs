using Picpay.Adapters.Cryptographies;
using Picpay.Infra.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection.Providers;

internal static class CryptographyInjection
{
    public static IServiceCollection AddCryptography(this IServiceCollection services, bool isDev)
    {
        return services.AddScoped<ICryptographys, TheWorstCrypt>();
    }
}


