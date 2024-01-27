namespace Picpay.UI.Controllers.Middlewares.ErrorHandlers;

public class DefaultErrorHandler
{
    private readonly RequestDelegate next;
    private readonly ILogger<DefaultErrorHandler> _logger;

    public DefaultErrorHandler(ILogger<DefaultErrorHandler> logger, RequestDelegate next)
    {
        this.next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // try
        // {
        await next(context);
        // }
        // catch (ValidationException e)
        // {
        //     context.Response.StatusCode = 400;

        //     var ers = e.ListErrorList();

        //     var body = new
        //     {
        //         Message = e.Message,
        //         Errors = ers
        //     };

        //     await context.Response.WriteAsJsonAsync(body);
        // }
    }
}



