using Picpay.Application.Features.ShopKeepers.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection.UseCases;

internal static class ShopKeeperUseCasesInjection
{
    public static IServiceCollection AddShopKeeperUseCases(this IServiceCollection services)
      => services
                .AddScoped<CreateShopKeeperUseCase>()
                .AddScoped<DeleteShopKeeperUseCase>()
                .AddScoped<SelectShopKeeperUseCase>()
      ;
}




