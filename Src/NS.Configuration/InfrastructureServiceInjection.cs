using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NS.Domain.Entities.Product;
using NS.Infrastructure.MSSQL.EFCore;
using NS.Infrastructure.MSSQL.EFCore.Repositories;

namespace NS.Configuration;

public static class InfrastructureServiceInjection
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var cnnString = configuration.GetConnectionString("NadinDB");
        
        services.AddDbContext<NadinContext>(x => x
            .UseSqlServer(cnnString));
        
        services.AddScoped<IProductRepository,ProductRepository>();
        
        return services;
    }
}