using Microsoft.Extensions.DependencyInjection;
using Picpay.DependencyInjection;

namespace Picpay.Unit;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var isDev = true;

        var connectionstring = "Server=localhost;Port=5432;Database=mydatabase_test;User Id=postgres;Password=postgres;";

        services
               .AddDatabase(connectionstring)
               .AddProviders(isDev)
               .AddRepositories(isDev)
               .AddUseCases();
    }
}

