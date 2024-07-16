using Application.Interfaces;
using Blogging.Domain.Services;
using Blogging.Infrastructure.Data;
using Blogging.Infrastructure.Email;
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
        
        services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(connectionString));        

        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

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
            .FirstOrDefault(x => x.ServiceType == typeof(DbContextOptions<AppDbContext>));
        if (existingSvc != null)
        {
            builder.Services.Remove(existingSvc!);
        }

        // Aspire
        builder.AddSqlServerDbContext<AppDbContext>(DbConnectionName,
            sqlServerSetting =>
            {
                //sqlServerSetting.DisableRetry = true;            
            },
            dbCtxOpts =>
            {
            });

        return builder;
    }
}
