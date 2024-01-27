namespace Picpay.Adapters.Authorization;

public interface IPaymentAuthorization
{
    Task<bool> IsAuthorized();
}
