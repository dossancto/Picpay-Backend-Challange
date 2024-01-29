namespace Picpay.Domain.Features.Transfer.Exceptions;
/// <summary>
/// Encapsulates all exceptions related to Transfer Fails
/// </summary>
public class TransferException : Exception
{
    private static readonly string DEFAULT_MESSAGE = "Fail while processing transfer, try again later.";

    /// <summary>
    /// Details about the operation
    /// </summary>
    public string ErrorDetails = string.Empty;

    /// <summary>
    /// Add error details
    /// </summary>
    public TransferException WithDetails(string error)
    {
        ErrorDetails = error;

        return this;
    }

    /// <summary>
    /// Generates a default and generic error message for Transfer fails
    /// </summary>
    public TransferException() : this(DEFAULT_MESSAGE, "") { }

    /// <summary>
    /// Encapsulates all exceptions related to Transfer Fails
    /// </summary>
    public TransferException(string msg) : this(msg, "") { }

    /// <summary>
    /// Transfer exceptions with details
    /// </summary>
    public TransferException(string msg, string details) : base(msg)
    {


    }
}
