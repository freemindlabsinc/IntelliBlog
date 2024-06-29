using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreeMindLabs.IntelliBlog.Infrastructure.Data;

public static class AppDbContextExtensions
{
  public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
  {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
  }
}
