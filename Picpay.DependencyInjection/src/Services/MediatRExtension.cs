namespace Picpay.DependencyInjection.Services;

public static class MediatRExtension
{
    public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
      => services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Application.Application).Assembly));
}
