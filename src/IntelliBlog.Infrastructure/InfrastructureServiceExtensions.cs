using IntelliBlog.Application.Interfaces;
using IntelliBlog.Infrastructure.Data;
using IntelliBlog.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntelliBlog.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    IConfiguration config)
  {        
    string? connectionString = config.GetConnectionString($"DbConnection");
    Guard.Against.Null(connectionString);

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));        
    
    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));
    
    return services;
  }
}
