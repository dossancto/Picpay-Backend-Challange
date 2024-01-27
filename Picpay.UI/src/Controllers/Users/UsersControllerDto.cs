using Picpay.Application.Features.Users.UseCases;

namespace Picpay.UI.Controllers.Users;

/// <summary>
/// Represents a request for updating a User
/// </summary>
public class UpdateUserRequest
{

    /// <summary>
    /// Fullname
    /// </summary>
    /// <example>Fullname</example>
    public string Fullname { get; set; } = default!;

    /// <summary>
    /// CPF
    /// </summary>
    /// <example>CPF</example>
    public string CPF { get; set; } = default!;

    /// <summary>
    /// Email
    /// </summary>
    /// <example>Email</example>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Password
    /// </summary>
    /// <example>Password</example>
    public string Password { get; set; } = default!;

    /// <summary>
    /// Salt
    /// </summary>
    /// <example>Salt</example>
    public string Salt { get; set; } = default!;

    /// <summary>
    /// Balance
    /// </summary>
    /// <example>Balance</example>
    public decimal Balance { get; set; }



    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    /// <returns>The note model.</returns>
    public UpdateUser ToModel(string id)
    => new()
    {
        Id = id,
        Fullname = Fullname,
        CPF = CPF,
        Email = Email,
        Password = Password,
        Salt = Salt,
        Balance = Balance
    };

}

