using Blogging.Application.Interfaces;
using Blogging.Domain.Interfaces;
using Blogging.Infrastructure.Data.Interceptors;
using Blogging.Infrastructure.Data;
using Blogging.Infrastructure.Email;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureExtensions
{
    public const string DbConnectionName = "IntelliBlogDb";
    public const string MailServerSectionName = "Mainserver";

    /// <summary>
    /// Registers AppDbContext, repositories, unit of work, and email sender.    
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration config)
    {
        // DbContext
        string? connectionString = config.GetConnectionString(DbConnectionName);
        Guard.Against.Null(connectionString);

        services.AddScoped<ISaveChangesInterceptor, TrackedEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, GenerateCreateUpdateDeleteEventsInterceptor>();

        services.AddDbContext<BloggingDbContext>(
            (sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);                
            });        

        // Repositories
        services.AddScoped(typeof(IEntityRepository<>), typeof(EntityFrameworkEntityRepository<>));

        // Unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Other
        services.Configure<MailserverConfiguration>(config.GetSection(MailServerSectionName));
        services.AddScoped<IEmailSender, MimeKitEmailSender>();

        return services;
    }

    /// <summary>
    /// Adds infrastructure services to IHostApplicationBuilder. 
    /// This extension method is to be used in the projects the Aspire AppHost references.
    /// </summary>
    public static IHostApplicationBuilder AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        // DbContext
        builder.Services.AddInfrastructureServices(builder.Configuration);

        ServiceDescriptor? existingSvc = builder.Services
            .FirstOrDefault(x => x.ServiceType == typeof(DbContextOptions<BloggingDbContext>));
        if (existingSvc != null)
        {
            builder.Services.Remove(existingSvc!);
        }

        // Aspire
        builder.AddSqlServerDbContext<BloggingDbContext>(DbConnectionName,
            sqlServerSetting =>
            {
                //sqlServerSetting.DisableRetry = true;            
            },
            dbCtxOpts =>
            {
            });

        return builder;
    }

    public static async Task SeedDataAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
                
        var context = services.GetRequiredService<BloggingDbContext>();
        
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        await SeedData.PopulateTestData(context);
    }
}
