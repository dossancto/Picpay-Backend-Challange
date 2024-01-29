using Picpay.Domain.Features.Accounts.Entities;

namespace Picpay.Domain.Features.Mercant.Entities;

/// <summary>
/// Merchant
/// </summary>
public class ShopKeeper : Account
{
    /// <summary>
    /// Id
    /// </summary>
    /// <example>Id</example>
    public string Id { get; set; } = string.Empty;
}

