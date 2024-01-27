using Picpay.Application.Features.Transfer.Entities;

namespace Picpay.Application.Features.Transfer.Data;

/// <summary>
/// Defines database operations for Transfers
/// </summary>
public interface ITransferRepository
{
    /// <summary>
    /// Execute the transaction to move money from an user to another.
    /// </summary>
    Task UserToUserTransfer(TransactionEntity entity);

    /// <summary>
    /// Execute the transaction to move money from an account to shopkeeper.
    /// </summary>
    Task UserToShopkeeperTransfer(TransactionEntity entity);
}
