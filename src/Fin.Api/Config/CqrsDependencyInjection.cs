using Fin.Domain.Interfaces.CQRS.Commands;
using Fin.Domain.Interfaces.CQRS.Queries;
using System.Reflection;

namespace Fin.Api.Config;

public static class CqrsDependencyInjection
{
    public static IServiceCollection AddCqrsHandlers(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        var handlerTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t is { IsClass: true, IsAbstract: false })
            .ToList();

        foreach (var implementationType in handlerTypes)
        {
            var interfaces = implementationType.GetInterfaces()
                .Where(i =>
                    i.IsGenericType &&
                    (
                        i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>) ||
                        i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)
                    ));

            foreach (var interfaceType in interfaces)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }

        return services;
    }
}