using Picpay.Application.Features.Users.Data;
using Picpay.Infra.Database.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection;

public static class RepositoriesInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, bool isDev)
    => services
              .AddScoped<IUserRepository, EFUserRepository>()
    ;
}


