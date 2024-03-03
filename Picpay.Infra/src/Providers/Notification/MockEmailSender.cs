using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Picpay.Adapters.Notification;
namespace Picpay.Infra.Providers.Notification;

internal record EmailSenderResponse(bool Message);

public class MockEmailSender
(ILogger<MockEmailSender> logger)
: IEmailSender
{
    private const string URL = "https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6";

    public async Task NotifyTransaction(NotifyEmailTransaction notification)
    {
        var msg = IEmailSender.TransactionMessage(notification);

        logger.LogInformation($"Email: {msg}");

        var client = new HttpClient();

        var response = await client.GetAsync(URL);

        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<EmailSenderResponse>(body);
    }
}
