using Picpay.Application.Features.Transfer.Data;
using Picpay.Domain.Features.Transfer.Entities;
using Picpay.Domain.Features.Transfer.Enums;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible for creating a TransactionEntity using a given repository.
/// </summary>
public class CreateTransactionEntityUseCase
(ITransactionEntityRepository _TransactionEntityRepository)
  : IUseCase
{
    /// <summary>
    /// Executes the creation of a TransactionEntity.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the TransactionEntity to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<TransactionEntity> Execute(CreateTransactionEntity dto)
    => _TransactionEntityRepository.Save(dto.ToModel());
}


/// <summary>
/// Represents a data object for creating a TransactionEntity
/// </summary>
public class CreateTransactionEntity
{
    /// <summary>
    /// Ammount
    /// </summary>
    /// <example>Ammount</example>
    public decimal Ammount { get; set; }

    /// <summary>
    /// Sender
    /// </summary>
    /// <example>Sender</example>
    public string Sender { get; set; } = default!;

    /// <summary>
    /// Receiver
    /// </summary>
    /// <example>Receiver</example>
    public string Receiver { get; set; } = default!;

    /// <summary>
    /// EventType
    /// </summary>
    /// <example>EventType</example>
    public TransactionEventType EventType { get; set; }

    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    /// <returns>The note model.</returns>
    public TransactionEntity ToModel()
    => new()
    {
        Ammount = Ammount,
        Sender = Sender,
        Receiver = Receiver,
        EventType = EventType,
    };
}

