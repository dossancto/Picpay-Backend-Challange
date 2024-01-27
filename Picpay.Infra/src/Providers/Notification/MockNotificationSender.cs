using Picpay.Adapters.Notification;
namespace Picpay.Infra.Providers.Notification;

public class MockNotificationSender : INofificationSender
{
    private readonly ISmsSender _smsSender;
    private readonly IEmailSender _emailSender;

    public MockNotificationSender(ISmsSender smsSender, IEmailSender emailSender)
    {
        _smsSender = smsSender;
        _emailSender = emailSender;
    }

    public Task NotifyTransaction(NotifySmsTransaction notification)
    => _smsSender.NotifyTransaction(notification);

    public Task NotifyTransaction(NotifyEmailTransaction notification)
    => _emailSender.NotifyTransaction(notification);
}

