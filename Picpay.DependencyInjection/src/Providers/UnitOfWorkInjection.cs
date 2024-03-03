using Picpay.Domain.Utils;
using Picpay.Infra.Database.EF.UnitOfWork;

namespace Picpay.DependencyInjection.Providers;

internal static class UnitOfWorkInjection
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, EFUnitOfWork>();

        return services;
    }
}



