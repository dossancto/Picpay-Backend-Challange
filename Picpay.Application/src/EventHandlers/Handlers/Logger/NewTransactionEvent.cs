using Microsoft.Extensions.Logging;
using MediatR;
using Picpay.Application.EventHandlers.Notifications.Transfer;

namespace Picpay.Application.EventHandlers.Handlers.Noficators;

public partial class LoggerEventHandler : INotificationHandler<NewTransactionEvent>
{

    /// <summary>
    /// Logs a new Transaction.
    /// </summary>
    public Task Handle(NewTransactionEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"New Transaction of {notification.Amount}");

        return Task.CompletedTask;
    }
}
