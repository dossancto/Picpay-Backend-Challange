using Picpay.Adapters.Notification;
namespace Picpay.Infra.Providers.Notification;

public class MockNotificationSender
(
   ISmsSender _smsSender,
   IEmailSender _emailSender)
: INofificationSender
{
    public Task NotifyTransaction(NotifySmsTransaction notification)
    => _smsSender.NotifyTransaction(notification);

    public Task NotifyTransaction(NotifyEmailTransaction notification)
    => _emailSender.NotifyTransaction(notification);
}

