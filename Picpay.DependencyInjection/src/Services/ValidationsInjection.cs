using FluentValidation;
namespace Picpay.DependencyInjection.Services;

public static class ValidationsInjection
{
    public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
        => services
        .AddValidatorsFromAssemblyContaining<Application.Application>()
        ;
}
