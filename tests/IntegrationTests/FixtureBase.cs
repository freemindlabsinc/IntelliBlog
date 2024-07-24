using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Blogging.IntegrationTests;

public abstract class FixtureBase
{
    IServiceProvider? _serviceProvider;
    ITestOutputHelper? _outputHelper;
    readonly IConfiguration _config;

    public FixtureBase()
    {
        _config = GetConfiguration();
    }

    protected virtual IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.testing.json")
            .AddUserSecrets<FixtureBase>()
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        //var _fakeEventDispatcher = Substitute.For<IDomainEventDispatcher>();
        //services.AddSingleton<IDomainEventDispatcher>(_fakeEventDispatcher);
        services.AddApplicationServices();
        services.AddInfrastructureServices(_config);
    }

    protected IServiceProvider GetServiceProvider()
    {
        if (_serviceProvider != null)
        {
            return _serviceProvider;
        }

        var _serviceCollection = new ServiceCollection();
        if (_outputHelper != null)
        {
            _serviceCollection.AddLogging((builder) => builder.AddXUnit(_outputHelper));
        };

        ConfigureServices(_serviceCollection);

        _serviceProvider = _serviceCollection.BuildServiceProvider();

        return _serviceProvider;
    }

    public void SetTestOutputHelper(ITestOutputHelper helper)
    {
        _outputHelper = helper;
    }

    public ITestOutputHelper? Output => _outputHelper;
    
}
