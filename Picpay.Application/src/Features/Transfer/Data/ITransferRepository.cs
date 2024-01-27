namespace Picpay.Application.Features.Transfer.Data;

/// <summary>
/// Defines database operations for Transfers
/// </summary>
public interface ITransferRepository
{
    /// <summary>
    /// Execute the transaction to move money from an account to another.
    /// </summary>
    Task UserToUserTransfer(string from, string to, decimal ammount);
}
