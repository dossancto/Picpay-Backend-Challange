using System.ComponentModel.DataAnnotations;
using Picpay.Application.Features.Accounts.Entities;

namespace Picpay.Application.Features.Accounts.UseCases;

/// <summary>
/// Represents a data object for creating a Account
/// </summary>
public record CreteAccount
{
    /// <summary>
    /// Fullname
    /// </summary>
    /// <example>Picpay Tester</example>
    [Required]
    public string Fullname { get; set; } = default!;

    /// <summary>
    /// CPF
    /// </summary>
    /// <example>00000000000</example>
    [Required]
    [Length(minimumLength: 11, maximumLength: 11)]
    public string CPF { get; set; } = default!;

    /// <summary>
    /// Email
    /// </summary>
    /// <example>test@test.com</example>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Password
    /// </summary>
    /// <example>A_Secure_Password</example>
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = default!;

    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    public Account ToModel(string salt)
    => new()
    {
        Fullname = Fullname,
        CPF = CPF,
        Email = Email,
        HashedPassword = string.Empty,
        Salt = salt,
        Balance = 0m
    };
}

