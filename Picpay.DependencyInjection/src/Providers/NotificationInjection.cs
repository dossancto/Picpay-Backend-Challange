using Microsoft.Extensions.DependencyInjection;
using Picpay.Adapters.Notification;
using Picpay.Infra.Providers.Notification;

namespace Picpay.DependencyInjection.Providers;

internal static class NotificationInjection
{
    public static IServiceCollection AddNotifications(this IServiceCollection services, bool isDev)
    => isDev
      ? services.AddMockNotifications()
      : services.AddProductionNotifications();

    private static IServiceCollection AddProductionNotifications(this IServiceCollection services)
      => services.AddMockNotifications();

    private static IServiceCollection AddMockNotifications(this IServiceCollection services)
      => services
      .AddScoped<IEmailSender, MockEmailSender>()
      .AddScoped<ISmsSender, MockSmsSender>()
      .AddScoped<INofificationSender, MockNotificationSender>()
      ;
}


