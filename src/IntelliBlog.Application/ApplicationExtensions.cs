using IntelliBlog.Domain.Aggregates.Articles;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using IntelliBlog.Domain.Aggregates.Blogs;
using IntelliBlog.Application.UseCases.Blogs.Create;
using IntelliBlog.Application.Behaviors;
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
