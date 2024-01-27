using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection;

public static class EnvironmentInjection
{
    public static IServiceCollection AddEnvironment(this IServiceCollection services, bool isDev)
    {
        Env.TraversePath().Load();

        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? throw new ArgumentException("<POSTGRES_CONNECTION_STRING> not found.");

        services.AddDatabase(connectionString);

        return services;
    }

}
