using System.Reflection;
using System.Runtime.InteropServices;
using Blogging.Application.Behaviors;
using Blogging.Domain.Interfaces;
using FluentValidation;
//using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // FluentValidation 
        services.AddValidatorsFromAssembly(            
            Assembly.GetExecutingAssembly(),
            includeInternalTypes: true); // this assembly

        // Mediator
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); // this assembly

            // Behaviors (MediatR pipeline)
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));            
        });

        // Domain Event Dispatcher (DDD)
        services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
        services.AddSingleton(TimeProvider.System);

        services.AddScoped<IUser>(sp => 
        {             
            return new User("APPLICATION");
        });

        return services;
    }

    internal class User(string? id) : IUser
    {
        public string? Id { get; } = id;
    }
}
