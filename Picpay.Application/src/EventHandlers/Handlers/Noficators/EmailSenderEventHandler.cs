using MediatR;
using Picpay.Adapters.Notification;
using Picpay.Application.EventHandlers.Notifications.Transfer;

namespace Picpay.Application.EventHandlers.Handlers.Noficators;

/// <summary>
/// Handles a new Transaction Event
/// </summary>
public class EmailSenderEventHandler : INotificationHandler<NewTransactionEvent>
{
    private readonly IMediator _mediator;
    private readonly INofificationSender _notificationSender;

    /// <summary>
    /// Dependency Inversion required servers
    /// </summary>
    public EmailSenderEventHandler(IMediator mediator, INofificationSender notificationSender)
    {
        _mediator = mediator;
        _notificationSender = notificationSender;
    }

    /// <summary>
    /// Handles a New Transaction Event
    /// </summary>
    async Task INotificationHandler<NewTransactionEvent>.Handle(NewTransactionEvent notification, CancellationToken cancellationToken)
    {
        await _notificationSender.NotifyTransaction(new NotifyEmailTransaction(notification.TargetEmail, notification.OriginatorEmail, notification.Amount));
    }
}

