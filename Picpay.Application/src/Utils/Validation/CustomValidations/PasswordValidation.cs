using FluentValidation;

namespace Picpay.Application.Utils.Validation.CustomValidations;

/// <summary>
/// Defines a validation for Password
/// </summary>
public static class PasswordValidation
{

    /// <summary>
    /// Check if the password has minimum security level.
    /// </summary>
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
      => ruleBuilder
         .NotEmpty().WithMessage("Password can not be empty.")
         .MinimumLength(8).WithMessage("Password must contain at least 8 characters.")
         .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
         .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
         .Matches(@"\d").WithMessage("Password must contain at least one digit.")
         .Matches(@"[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
}
