using System.Reflection;
using Application.Behaviors;
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

            // Domain Event Dispatcher (DDD)
            services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
        });

        return services;
    }
}
