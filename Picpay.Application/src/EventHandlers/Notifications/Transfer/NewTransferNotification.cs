using MediatR;

namespace Picpay.Application.EventHandlers.Notifications.Transfer;

/// <summary>
/// Represents a new Transaction was made.
/// </summary>
public class NewTransactionEvent : INotification
{
    /// <summary>
    /// Represents the Email address to send a email
    /// </summary>
    /// <example>john@doe.com</example>
    public required string TargetEmail { get; set; }

    /// <summary>
    /// Email of who originates the Email
    /// </summary>
    /// <example>picpay@picpay.com</example>
    public required string OriginatorEmail { get; set; }

    /// <summary>
    /// Represents the transaction amount
    /// </summary>
    /// <example>50.99</example>
    public decimal Amount { get; set; }
}

