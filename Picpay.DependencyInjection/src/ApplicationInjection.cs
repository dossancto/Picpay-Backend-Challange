using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection;

public static class ApplicationInjection
{
    public static IServiceCollection AddDefaultApplicationConfiguration(this IServiceCollection services, bool isDev = false)
    {
        var mode = isDev ? "dev" : "prod";
        Console.WriteLine($"Runing in {mode} mode");

        return services.AddDefaultApplication(isDev);
    }

    private static IServiceCollection AddDefaultApplication(this IServiceCollection services, bool isDev)
    => services
            .AddEnvironment(isDev)
            .AddProviders(isDev)
            .AddRepositories(isDev)
            .AddUseCases()
    ;
}

