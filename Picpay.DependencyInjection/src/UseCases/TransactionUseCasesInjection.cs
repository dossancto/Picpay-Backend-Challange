using Picpay.Application.Features.Transfer.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection.UseCases;

internal static class TransactionUseCasesInjection
{
    public static IServiceCollection AddTransactionUseCases(this IServiceCollection services)
      => services
                .AddScoped<CreateTransactionEntityUseCase>()
                .AddScoped<SelectTransactionEntityUseCase>()
      ;
}





