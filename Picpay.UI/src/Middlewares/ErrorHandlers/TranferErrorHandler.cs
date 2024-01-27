using Picpay.Application.Features.Transfer.Exceptions;

namespace Picpay.UI.Controllers.Middlewares.ErrorHandlers;

public class TranferErrorHandler
{
    private readonly RequestDelegate next;
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<TranferErrorHandler> _logger;

    public TranferErrorHandler(ILogger<TranferErrorHandler> logger, RequestDelegate next, IWebHostEnvironment env)
    {
        this.next = next;
        _env = env;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (TransferException e)
        {
            context.Response.StatusCode = 400;

            if (_env.IsProduction())
            {
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = e.Message,
                    details = e.ErrorDetails,
                });
                return;
            }

            await context.Response.WriteAsJsonAsync(new
            {
                Message = e.Message,
                details = e.ErrorDetails,
                Stacktrace = e.StackTrace
            });
        }
    }
}



