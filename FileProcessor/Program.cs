using FileProcessor.Core;
using FileProcessor.Core.Interfaces;
using FileProcessor.Infrastructure;
using FileProcessor.Infrastructure.Database;
using FileProcessor.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IFileProcessorContext, FileProcessorContext>();
builder.Services.AddDbContext<FileProcessorContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));
builder.Services.Configure<MessagingPolicySettings>(builder.Configuration.GetSection("MessagingPolicySettings"));
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FileProcessorContext>();

    var pendingMigrations = dbContext.Database.GetPendingMigrations();
    if (pendingMigrations.Any())
    {
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();


app.Run();