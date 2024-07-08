using Blogging.Domain.Aggregates.Articles;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Blogging.Domain.Aggregates.Blogs;
using Blogging.Application.UseCases.Blogs.Create;
using Blogging.Application.Behaviors;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;
public static class ApplicationExtensions
{    
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
        IConfiguration config)
    {
        services.ConfigureMediatR();

        services.AddValidatorsFromAssemblyContaining<CreateBlogCommandValidator>();

        return services;
    }

    static void ConfigureMediatR(this IServiceCollection services)
    {
        var mediatRAssemblies = new[]
        {
          Assembly.GetAssembly(typeof(Blog)), // Domain
          Assembly.GetAssembly(typeof(CreateBlogCommand)) // UseCases
        };
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));
        services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
    }
}
