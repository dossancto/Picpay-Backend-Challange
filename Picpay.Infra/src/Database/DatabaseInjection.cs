using Picpay.Infra.Database.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Picpay.Infra.Database;

public static class DatabaseInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? throw new ArgumentException("<POSTGRES_CONNECTION_STRING> not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
