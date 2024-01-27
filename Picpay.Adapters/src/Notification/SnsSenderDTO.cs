namespace Picpay.Adapters.Notification;

public record NotifySmsTransaction(string TargetNumber, string To, decimal Ammount);
