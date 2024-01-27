namespace Picpay.UI.Controllers.Middlewares.ErrorHandlers;

public class GenericErrorHandler
{
    private readonly RequestDelegate next;
    private readonly ILogger<GenericErrorHandler> _logger;

    public GenericErrorHandler(ILogger<GenericErrorHandler> logger, RequestDelegate next)
    {
        this.next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(new
            {
                Message = "Something went wrong, try again later"
            });
        }
    }
}



