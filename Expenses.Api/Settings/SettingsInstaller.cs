using Expenses.Infrastructure.Settings;

namespace ExpensesApi.Settings;

public static class SettingsInstaller
{
    public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<MessagingPolicySettings>(configuration.GetSection("MessagingPolicySettings"));
    }
}