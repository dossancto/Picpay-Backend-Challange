using FluentValidation;
using Picpay.Domain.Exceptions;

namespace Picpay.Application.Utils.Validation;

/// <summary>
/// Apply Custom actions when valiting.
/// </summary>
public static class ValidationChecker
{

    /// <summary>
    /// Validates the Item, if invaldi throws an error.
    /// </summary>
    public static void Check<T>(this IValidator<T> validator, T value, string message)
    {
        var result = validator.Validate(value);

        if (result.IsValid)
        {
            return;
        }

        var errors = result
          .Errors
          .Select(e => new ValidationError(e.PropertyName, e.ErrorMessage))
          .ToList();

        throw new ValidationFailException(message, errors);
    }
}
