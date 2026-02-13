using Expenses.ApplicationCore.Interfaces;
using ExpensesApi.Settings;
using Expenses.Infrastructure.Database;
using Expenses.Infrastructure.Identity;
using ExpensesApi.Initializers;
using ExpensesApi.Modules;
using ExpensesApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.ConfigureSettings(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IHttpContextResolver, HttpContextResolver>();

builder.Services
    .AddIdentity<IdentityApplicationUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddApplicationServices();
builder.Services.ConfigureAuthentication(builder.Configuration);

var app = builder.Build();

app.MigrateDatabase();
app.SetupExchanges();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
