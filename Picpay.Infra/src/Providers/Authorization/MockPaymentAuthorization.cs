using Newtonsoft.Json;
using Picpay.Adapters.Authorization;

namespace Picpay.Infra.Providers.Authorization;

public record MockPaymentResponse(string Message);

public class MockPaymentAuthorization : IPaymentAuthorization
{
    public async Task<bool> IsAuthorized()
    {
        var client = new HttpClient();

        var response = await client.GetAsync("https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc");

        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<MockPaymentResponse>(body);

        return result?.Message == "Autorizado";
    }
}
