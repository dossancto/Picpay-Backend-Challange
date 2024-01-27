using Picpay.Application.Features.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace Picpay.UI.Controllers.Users;

/// <summary>
/// User representation without sensive data.
/// </summary>
public record SafeUserResponse
{
    /// <summary>
    /// The full user name .
    /// </summary>
    /// <example>All Might</example>
    [Required]
    public string Name { get; set; } = default!;

    /// <summary>
    /// The user email, its a valid email address
    /// </summary>
    /// <example>allMight@ua.com</example>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Converts a user entity into a safe version
    /// without sensive information.
    /// </summary>
    public static SafeUserResponse From(User x)
      => new()
      {
          Name = x.Name,
          Email = x.Email
      };
}
