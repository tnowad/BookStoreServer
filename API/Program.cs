
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var logger = builder.Logging.Services.BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger("Startup");

logger.LogInformation("Starting application setup...");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    logger.LogCritical("Connection string not found. Application cannot start.");
    throw new InvalidOperationException("Connection string not found");
}
logger.LogInformation("Connection string found. Configuring infrastructure...");

builder.Services.AddInfrastructure(
    connectionString
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    logger.LogInformation("Development environment detected. Enabling Swagger...");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    logger.LogInformation("Production environment detected. Swagger is disabled.");
}

logger.LogInformation("Configuring middleware...");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

logger.LogInformation("Application setup complete. Starting application...");
app.Run();

