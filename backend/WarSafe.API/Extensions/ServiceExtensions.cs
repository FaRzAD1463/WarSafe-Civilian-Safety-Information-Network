using Microsoft.EntityFrameworkCore;
using WarSafe.Infrastructure;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("Default")));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAlertService, AlertService>();
        services.AddScoped<IShelterService, ShelterService>();
    }
}
