using FluentValidation;
using Picpay.Application.Utils.Validation.CustomValidations;
using Picpay.Application.Features.Accounts.UseCases;

namespace Picpay.Application.Features.Accounts.Validations;

/// <summary>
/// Defines validation for creating a Account
/// </summary>
public class CreateAccountValidation : AbstractValidator<CreteAccount>
{
    /// <summary>
    /// General rules for creating a Account
    /// </summary>
    public CreateAccountValidation()
    {
        RuleFor(x => x.Fullname).MinimumLength(5);

        // TODO: Add more validations for CPF
        RuleFor(x => x.CPF).Length(11);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).Password();
    }
}

