using Microsoft.Extensions.Logging;

namespace Picpay.Application.EventHandlers.Handlers.Noficators;

/// <summary>
/// Handle Logs information from selected events.
/// </summary>
public partial class LoggerEventHandler
{
    private readonly ILogger<LoggerEventHandler> _logger;

    /// <summary>
    /// Dependency Inversion required servers
    /// </summary>
    public LoggerEventHandler(ILogger<LoggerEventHandler> logger)
    {
        _logger = logger;
    }
}



