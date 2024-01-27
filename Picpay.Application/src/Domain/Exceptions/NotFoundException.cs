namespace Picpay.Application.Domain.Exceptions;

/// <summary>
/// Represents a not found resource. 
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Represents a not found resource. 
    /// </summary>
    public NotFoundException(string msg) : base(msg) { }
}
