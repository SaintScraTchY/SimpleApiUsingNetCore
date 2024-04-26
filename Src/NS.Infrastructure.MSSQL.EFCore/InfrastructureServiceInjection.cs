using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NS.Domain.Entities.Product;
using NS.Infrastructure.MSSQL.EFCore.Repositories;

namespace NS.Infrastructure.MSSQL.EFCore;

public static class InfrastructureServiceInjection
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var cnnString = configuration.GetConnectionString("NadinDB");
        
        services.AddDbContext<NadinContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString(cnnString)));
        
        services.AddScoped<IProductRepository,ProductRepository>();
        
        return services;
    }
}