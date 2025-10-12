using SecretsDemo.Configuration;
using SecretsDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ExternalLoggerOptions>(
    builder.Configuration.GetSection(ExternalLoggerOptions.ExternalLogger)
);

builder.Services.AddSingleton<LoggerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/log", (LoggerService logger) => 
    Results.Ok((object?)logger.LogMessage("Test message from the API")));

app.Run();
