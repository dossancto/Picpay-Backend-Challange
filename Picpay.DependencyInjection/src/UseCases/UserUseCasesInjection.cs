using Picpay.Application.Features.Users.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection.UseCases;

internal static class UserUseCasesInjection
{
    public static IServiceCollection AddUserUseCases(this IServiceCollection services)
      => services
                .AddScoped<RegisterUserUseCase>()
                .AddScoped<LoginUserUseCase>()
                .AddScoped<DeleteUserUseCase>()
      ;
}




