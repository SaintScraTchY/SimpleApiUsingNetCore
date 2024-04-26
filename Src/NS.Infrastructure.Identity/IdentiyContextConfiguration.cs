using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NS.Application.Contracts.Identity;
using NS.Application.Models.Auth;
using NS.Infrastructure.Identity.Models;
using NS.Infrastructure.Identity.Services;

namespace NS.Infrastructure.Identity;

public static class IdentityServiceInjection
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));

        services.AddDbContext<AppIdentityContext>(options => options.UseSqlServer(configuration.GetConnectionString("NadinDB"),
            b => b.MigrationsAssembly(typeof(AppIdentityContext).Assembly.FullName)));
        
        services.AddIdentity<AppUser,IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtOptions =>
        {
            JwtOptions.SaveToken = true;
            JwtOptions.RequireHttpsMetadata = false;
            JwtOptions.SaveToken = false;
            JwtOptions.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer  = configuration["JwtSetting:Issuer"],
                ValidAudience  = configuration["JwtSetting:Audience"],
                IssuerSigningKey  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Audience"])),
            };
        });

        services.AddTransient<IAuthenticationService, AuthenticationService>();
        
        return services;
    }
}