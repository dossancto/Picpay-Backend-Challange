using Picpay.Application.Features.Transfer.Enums;

namespace Picpay.Application.Features.Transfer.Entities;

/// <summary>
/// TransactionEntity
/// </summary>
public class TransactionEntity
{
    /// <summary>
    /// Id
    /// </summary>
    /// <example>Id</example>
    public string Id { get; set; } = default!;

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
    /// CreatedAt
    /// </summary>
    /// <example>CreatedAt</example>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

