using Blogging.Application.Interfaces;
using Blogging.Domain.Services;
using Blogging.Infrastructure.Data;
using Blogging.Infrastructure.Email;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration config)
    {
        // DbContext
        string? connectionString = config.GetConnectionString($"IntelliBlogDb");
        Guard.Against.Null(connectionString);

        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(connectionString));        

        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

        // Unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Other
        services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));
        services.AddScoped<IEmailSender, MimeKitEmailSender>();

        return services;
    }
}
