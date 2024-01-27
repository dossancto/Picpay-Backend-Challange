
using Picpay.Application.Features.Transfer.Data;
using Picpay.Application.Features.Transfer.Entities;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible getting data from TransactionEntitys
/// </summary>
public class SelectTransactionEntityUseCase
{
    private readonly ITransactionEntityRepository _TransactionEntityRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SelectTransactionEntityUseCase"/> class.
    /// </summary>
    /// <param name="TransactionEntityRepository">The TransactionEntity repository.</param>
    public SelectTransactionEntityUseCase(ITransactionEntityRepository TransactionEntityRepository)
    {
        _TransactionEntityRepository = TransactionEntityRepository;
    }

    /// <summary>
    /// Retrieves a note by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the note.</param>
    /// <returns>The task result contains the note if found, null otherwise.</returns>
    public Task<TransactionEntity?> ById(string id)
    => _TransactionEntityRepository.FindById(id);

    /// <summary>
    /// Retrieves all notes.
    /// </summary>
    /// <returns>The task result contains a list of all notes.</returns>
    public Task<List<TransactionEntity>> All()
    => _TransactionEntityRepository.All();
}


