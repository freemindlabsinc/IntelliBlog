using Ardalis.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit.Abstractions;
using IntelliBlog.Infrastructure;
using IntelliBlog.IntegrationTests._garbage;
using MediatR;

namespace IntelliBlog.IntegrationTests;

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
            .AddUserSecrets<BaseEfRepoTestFixture>()
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        var _fakeEventDispatcher = Substitute.For<IDomainEventDispatcher>();
        services.AddSingleton(_fakeEventDispatcher);
        services.AddApplicationServices(_config);
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

    public ISender Sender => GetServiceProvider()!.GetService<ISender>()!;
}
