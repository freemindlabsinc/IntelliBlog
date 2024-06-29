using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using FreeMindLabs.IntelliBlog.Core.Interfaces;
using FreeMindLabs.IntelliBlog.Core.Services;
using FreeMindLabs.IntelliBlog.Infrastructure.Data;
using FreeMindLabs.IntelliBlog.Infrastructure.Data.Queries;
using FreeMindLabs.IntelliBlog.Infrastructure.Email;
using FreeMindLabs.IntelliBlog.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FreeMindLabs.IntelliBlog.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString($"DbConnection");
    Guard.Against.Null(connectionString);    

    services.AddApplicationDbContext(connectionString);
    
    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IDeleteContributorService, DeleteContributorService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
