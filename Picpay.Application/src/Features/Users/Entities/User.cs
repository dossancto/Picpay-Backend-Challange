
using Picpay.Application.Features.Accounts.Entities;

namespace Picpay.Application.Features.Users.Entities;

/// <summary>
/// Represents a user entity
/// </summary>
public class User : Account
{
    /// <summary>
    /// Id
    /// </summary>
    /// <example>Id</example>
    public string Id { get; set; } = default!;
}

