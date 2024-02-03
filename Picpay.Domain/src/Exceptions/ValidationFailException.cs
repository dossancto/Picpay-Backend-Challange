namespace Picpay.Domain.Exceptions;

public record ValidationError(string Field, string Message);
public record ValidationFieldWithErrors(string Field, IEnumerable<string> Errors);

public class ValidationFailException : Exception
{
    public List<ValidationError> Errors { get; private set; }

    public ValidationFailException(string msg, List<ValidationError> errors) : base(msg)
     => Errors = errors;

    public ValidationFailException(string msg)
      : this(msg, new List<ValidationError>()) { }

    public override string ToString()
    {
        var erros = string.Join("\n", Errors);
        return $"{Message}\n-----------\n{erros}";
    }

    public List<ValidationFieldWithErrors> ListErrorList()
      => Errors
              .GroupBy(x => x.Field)
              .Select(x => new ValidationFieldWithErrors(x.Key, x.Select(y => y.Message)))
              .ToList();
}
