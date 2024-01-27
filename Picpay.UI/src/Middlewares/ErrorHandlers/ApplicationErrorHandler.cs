namespace Picpay.UI.Controllers.Middlewares.ErrorHandlers;

public static class ApplicationErrorHandler
{
    public static IApplicationBuilder AddErrorHandlers(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<DefaultErrorHandler>();

        if (env.IsProduction())
        {
            app.UseMiddleware<GenericErrorHandler>();
        }

        app.UseMiddleware<TranferErrorHandler>();

        return app;
    }
}

