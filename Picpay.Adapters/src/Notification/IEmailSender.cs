namespace Picpay.Adapters.Notification;

public interface IEmailSender
{
    Task NotifyTransaction(NotifyEmailTransaction notification);

    protected static string TransactionMessage(NotifyEmailTransaction notification)
      => $"Transaction sended to user {notification.To}, ammount: {notification.Ammount}";
}

