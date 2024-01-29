namespace Picpay.Domain.Features.Accounts.Entities;

/// <summary>
/// Represents a generic account entity
/// </summary>
public class Account
{
    /// <summary>
    /// Fullname
    /// </summary>
    /// <example>Picpay Tester</example>
    public string Fullname { get; set; } = default!;

    /// <summary>
    /// Email
    /// </summary>
    /// <example>test@test.com</example>
    public string Email { get; set; } = default!;

    /// <summary>
    /// CPF
    /// </summary>
    /// <example>00000000000</example>
    public string CPF { get; set; } = default!;

    /// <summary>
    /// HashedPassword
    /// </summary>
    /// <example>HashedPassword</example>
    public string HashedPassword { get; set; } = default!;

    /// <summary>
    /// Salt
    /// </summary>
    /// <example>Salt</example>
    public string Salt { get; set; } = default!;

    /// <summary>
    /// Balance
    /// </summary>
    /// <example>299.99</example>
    public decimal Balance { get; set; }
}

