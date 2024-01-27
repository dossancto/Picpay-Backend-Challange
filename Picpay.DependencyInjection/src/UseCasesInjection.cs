using Picpay.DependencyInjection.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection;

public static class UseCasesInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
      => services
                .AddUserUseCases()
                .AddTransferUseCases()
                .AddShopKeeperUseCases()
                ;
}



