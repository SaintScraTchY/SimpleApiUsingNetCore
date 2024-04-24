using Microsoft.EntityFrameworkCore;
using NS.Application;
using NS.Configuration;
using NS.Infrastructure.MSSQL.EFCore;

namespace NS.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureApplication();
        builder.Services.ConfigureInfrastructure(builder.Configuration);
        builder.Services.AddControllers();

        // builder.Services.AddCors(options =>
        // {
        // })
        
        return builder.Build();
    }

    public static async Task CreateDataBase(this WebApplication app)
    {
        
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<NadinContext>();
            if (context == null)
            {
                await context.Database.MigrateAsync();
            }
            
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}