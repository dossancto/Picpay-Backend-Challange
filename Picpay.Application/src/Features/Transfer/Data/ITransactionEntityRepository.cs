
using Picpay.Application.Features.Transfer.Entities;

namespace Picpay.Application.Features.Transfer.Data;

/// <summary>
/// Defines operations for a TransactionEntity repository.
/// </summary>
public interface ITransactionEntityRepository
{
    /// <summary>
    /// Save a new TransactionEntity
    /// </summary>
    /// <param name="entity">The entity to save</param>
    /// <returns>The created TransactionEntity</returns>
    Task<TransactionEntity> Save(TransactionEntity entity);

    /// <summary>
    /// Save a new TransactionEntity. But without save the context.
    /// </summary>
    /// <param name="entity">The entity to save</param>
    public void SaveNoChanges(TransactionEntity entity);

    /// <summary>
    /// Update a existint TransactionEntity
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <returns>The updated TransactionEntity</returns>
    Task<TransactionEntity> Update(TransactionEntity entity);

    /// <summary>
    /// Search for a TransactionEntity using it Id
    /// </summary>
    /// <param name="id">The Entity Id</param>
    /// <returns>The search result or null, if not found</returns>
    Task<TransactionEntity?> FindById(string id);

    /// <summary>
    /// List all TransactionEntity
    /// </summary>
    /// <returns>A list of all TransactionEntity</returns>
    Task<List<TransactionEntity>> All();

    /// <summary>
    /// Delete a TransactionEntity
    /// </summary>
    Task Delete(string id);

}
