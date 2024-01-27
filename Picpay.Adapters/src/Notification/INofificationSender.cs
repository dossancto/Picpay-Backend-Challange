namespace Picpay.Adapters.Notification;

public record NotifyAllTransaction(string TargetEmail, string TargetPhone, string To, decimal Ammount);

public interface INofificationSender : IEmailSender, ISmsSender
{
    public async Task<bool> TrySendNotifications(NotifyAllTransaction n)
    {
        try
        {
            await this.NotifyTransaction(
                new NotifyEmailTransaction(n.TargetEmail, n.To, n.Ammount));

            await this.NotifyTransaction(
                new NotifySmsTransaction(n.TargetPhone, n.To, n.Ammount));

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
