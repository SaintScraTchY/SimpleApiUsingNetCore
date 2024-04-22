using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NS.Application;

public static class ApplicationServiceConfiguration
{
    public static IServiceCollection Configure(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        return services;
    }
}