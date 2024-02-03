using Picpay.DependencyInjection.UseCases;

namespace Picpay.DependencyInjection;

public static class UseCasesInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
      => services
                .AddUserUseCases()
                .AddTransferUseCases()
                .AddTransactionUseCases()
                .AddShopKeeperUseCases()
                ;
}



