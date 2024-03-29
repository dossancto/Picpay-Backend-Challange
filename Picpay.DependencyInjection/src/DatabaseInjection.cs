using Picpay.Infra.Database;

namespace Picpay.DependencyInjection;

public static class DatabaseInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDatabaseInfra(connectionString);

        return services;
    }

    public static IServiceCollection AddDatabaseInMemory(this IServiceCollection services)
    {
        return services.AddDatabaseInfraInMemory();
    }
}

