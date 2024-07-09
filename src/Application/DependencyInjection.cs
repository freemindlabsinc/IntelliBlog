using System.Reflection;
using Blogging.Application.Behaviors;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // FluentValidation 
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // this assembly

        // Mediator
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); // this assembly

            // Behaviors (MediatR pipeline)
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            // Domain Event Dispatcher (DDD)
            services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
        });

        return services;
    }
}
