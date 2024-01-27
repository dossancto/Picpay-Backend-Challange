using Picpay.Application.Features.Transfer.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection.UseCases;

internal static class TransferUseCasesInjection
{
    public static IServiceCollection AddTransferUseCases(this IServiceCollection services)
      => services
                .AddScoped<UserToUserTransferUseCase>()
      ;
}




