using System.Configuration;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Contributor;
using IntelliBlog.Infrastructure;
using IntelliBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace IntelliBlog.IntegrationTests.Data;

public abstract class BaseEfRepoTestFixture
{
  protected AppDbContext _dbContext;

  protected BaseEfRepoTestFixture()
  {
    var options = CreateNewContextOptions();
    var _fakeEventDispatcher = Substitute.For<IDomainEventDispatcher>();

    _dbContext = new AppDbContext(options, _fakeEventDispatcher);
  }

  protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
  {
        // Create a fresh service provider        
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.testing.json")
            .AddUserSecrets<BaseEfRepoTestFixture>()
            .Build();

        var logger = new LoggerFactory()
            .CreateLogger<BaseEfRepoTestFixture>();

        var connString = config.GetConnectionString("DbConnection");    
        Guard.Against.NullOrEmpty(connString, "DbConnection");

        var serviceProvider = new ServiceCollection()
            .AddInfrastructureServices(config)
            //.AddEntityFrameworkSqlServerDatabase()
            //.AddEntityFrameworkInMemoryDatabase()            
            //.AddInfrastructureServices(config, logger)
            .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlServer(connString)
               .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

    protected EfRepository<Contributor> GetContributorRepository()
    {
        return new EfRepository<Contributor>(_dbContext);
    }

    protected EfRepository<Article> GetArticlesRepository()
    {
        return new EfRepository<Article>(_dbContext);
    }
}
