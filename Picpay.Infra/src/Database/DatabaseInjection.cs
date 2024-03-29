using Picpay.Infra.Database.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.Infra.Database;

public static class DatabaseInjection
{
    public static IServiceCollection AddDatabaseInfra(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddDatabaseInfraInMemory(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("mydatabase_test");
        });

        return services;
    }

}
