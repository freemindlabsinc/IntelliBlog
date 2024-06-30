using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using IntelliBlog.Application.Interfaces;
using IntelliBlog.Application.Services;
using IntelliBlog.Application.UseCases.Contributors.List;
using IntelliBlog.Infrastructure.Data;
using IntelliBlog.Infrastructure.Data.Queries;
using IntelliBlog.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
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

    services.AddApplicationDbContext(connectionString);
    
    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IContributorDeleteService, ContributorDeleteService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));
    
    return services;
  }
}
