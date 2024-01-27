using Microsoft.Extensions.DependencyInjection;
using Picpay.Adapters.Cryptographies;
using Picpay.Unit.Mock.Providers.Cryptographys;
using Picpay.DependencyInjection;

namespace Picpay.Unit;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICryptographys, CryptographysMock>();

        services.AddUseCases();
    }
}

