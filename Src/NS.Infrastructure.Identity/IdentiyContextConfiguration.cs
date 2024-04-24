using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NS.Infrastructure.Identity.Models;

namespace NS.Infrastructure.Identity;

public static class IdentityContextConfiguration
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var cnnString = configuration.GetConnectionString("NadinDB");
        
        
        services.AddIdentityCore<AppUser>()
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
            JwtOptions.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["jwt:Secret"]))
            };
        });
        
        
        
        return services;
    }
}