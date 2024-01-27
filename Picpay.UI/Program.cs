using Picpay.DependencyInjection;
using Picpay.UI.Configurations;
using Picpay.UI.Controllers.Middlewares.ErrorHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddDefaultApplicationConfiguration(builder.Environment.IsDevelopment());

builder.Services.AddControllers();

builder.Services.AddOpenAPI();

var app = builder.Build();

app.UseOpenAPI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddErrorHandlers(app.Environment);

app.Run();
