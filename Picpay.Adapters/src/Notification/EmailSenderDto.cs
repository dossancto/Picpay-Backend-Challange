namespace Picpay.Adapters.Notification;

public record NotifyEmailTransaction(string TargetEmail, string To, decimal Ammount);
