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
        string? connectionString = config.GetConnectionString($"IntelliBlogDb");
        Guard.Against.Null(connectionString);

        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(connectionString));        

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));
        services.AddScoped<IEmailSender, MimeKitEmailSender>();

        return services;
    }
}
