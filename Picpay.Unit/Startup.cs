using Microsoft.Extensions.DependencyInjection;
using Picpay.DependencyInjection;

namespace Picpay.Unit;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var isDev = true;

        services
               .AddDatabaseInMemory()
               .AddProviders(isDev)
               .AddRepositories(isDev)
               .AddUseCases();
    }
}

