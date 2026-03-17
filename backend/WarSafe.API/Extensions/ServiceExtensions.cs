using Microsoft.EntityFrameworkCore;
using WarSafe.Infrastructure;
using WarSafe.Application;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("Default")));

        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddHttpClient<AiService>();
    }
}