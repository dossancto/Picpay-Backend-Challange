using Picpay.Application.Features.Users.Data;
using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Infra.Database.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Picpay.Application.Features.Transfer.Data;

namespace Picpay.DependencyInjection;

public static class RepositoriesInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, bool isDev)
    => services
              .AddScoped<IUserRepository, EFUserRepository>()
              .AddScoped<IShopKeeperRepository, EFShopKeeperRepository>()
              .AddScoped<ITransferRepository, EFTransferRepository>()
              .AddScoped<ITransactionEntityRepository, EFTransactionEntityRepository>()
    ;
}


