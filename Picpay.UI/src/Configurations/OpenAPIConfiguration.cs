using System.Reflection;
namespace Picpay.UI.Configurations;

/// <summary>
/// Setup a OpenAPI defualt configuration.
/// </summary>
public static class OpenAPIConfiguration
{

    /// <summary>
    /// Adds and configure Swagger.
    /// Applyes Documentation SQL Files
    /// </summary>
    public static IServiceCollection AddOpenAPI(this IServiceCollection services)
    => services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());

                var assemblies = new List<string>() { GetRunningAssembly(), GetApplicationAssembly() };

                var baseDir = System.AppContext.BaseDirectory;

                foreach (var ass in assemblies)
                {
                    var path = Path.Combine(System.AppContext.BaseDirectory, $"{ass}.xml");

                    c.IncludeXmlComments(path);
                }
            });

    /// <summary>
    /// Use Swagger and Redoc
    /// </summary>
    public static IApplicationBuilder UseOpenAPI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseReDoc(options =>
        {
            options.DocumentTitle = "Endpoints documentation";
            options.SpecUrl = "/swagger/v1/swagger.json";
        });

        return app;
    }


    private static string GetRunningAssembly()
      => Assembly.GetExecutingAssembly().GetName().Name!;

    private static string GetApplicationAssembly()
    {
        Type applicationType = typeof(Picpay.Application.Application);

        return Assembly.GetAssembly(applicationType)?.GetName().Name!;
    }
}

