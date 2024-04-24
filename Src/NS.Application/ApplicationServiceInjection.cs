using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NS.Application;

public static class ApplicationServiceInjection
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config=>config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}