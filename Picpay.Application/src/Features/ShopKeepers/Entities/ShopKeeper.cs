using Picpay.Application.Features.Accounts.Entities;

namespace Picpay.Application.Features.ShopKeepers.Entities;

/// <summary>
/// ShopKeeper
/// </summary>
public class ShopKeeper : Account
{
    /// <summary>
    /// Id
    /// </summary>
    /// <example>Id</example>
    public string Id { get; set; } = string.Empty;
}

