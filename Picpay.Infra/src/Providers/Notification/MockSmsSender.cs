using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Picpay.Adapters.Notification;
namespace Picpay.Infra.Providers.Notification;

internal record SmsSenderResponse(bool Message);

public class MockSmsSender : ISmsSender
{
    private const string URL = "https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6";
    private readonly ILogger<MockSmsSender> logger;

    public MockSmsSender(ILogger<MockSmsSender> logger)
    {
        this.logger = logger;
    }

    public async Task NotifyTransaction(NotifySmsTransaction notification)
    {
        var msg = ISmsSender.TransactionMessage(notification);

        logger.LogInformation($"SMS: {msg}");

        var client = new HttpClient();

        var response = await client.GetAsync(URL);

        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<EmailSenderResponse>(body);
    }
}
