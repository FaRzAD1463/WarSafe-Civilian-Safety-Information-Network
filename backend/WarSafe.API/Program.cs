using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WarSafe.API.Middleware;
using WarSafe.API.Filters;
using WarSafe.API.Extensions;
using WarSafe.Application.Interfaces;
using WarSafe.Application.Services;
using WarSafe.Infrastructure;
using WarSafe.Infrastructure.Repositories;
using WarSafe.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

#region DATABASE

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

#endregion

#region DEPENDENCY INJECTION

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<IShelterService, ShelterService>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ReportRepository>();

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<EmailService>();

#endregion

#region AUTHENTICATION (JWT)

var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),

            ValidateIssuer = false,
            ValidateAudience = false,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

#endregion

#region CONTROLLERS + FILTERS

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

#endregion

#region SWAGGER

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "WarSafe API", Version = "v1" });

    // JWT support in Swagger
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter JWT token"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

#endregion

var app = builder.Build();

#region MIDDLEWARE PIPELINE

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
