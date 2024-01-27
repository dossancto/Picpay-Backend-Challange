namespace Picpay.Adapters.Notification;

public interface ISmsSender
{
    Task NotifyTransaction(NotifySmsTransaction notification);

    protected static string TransactionMessage(NotifySmsTransaction notification)
      => $"Transaction sended to user {notification.To}, ammount: {notification.Ammount}";
}

