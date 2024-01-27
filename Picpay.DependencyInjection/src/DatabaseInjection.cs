using Picpay.Infra.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.DependencyInjection;

public static class DatabaseInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDatabaseInfra(connectionString);

        return services;
    }

}

