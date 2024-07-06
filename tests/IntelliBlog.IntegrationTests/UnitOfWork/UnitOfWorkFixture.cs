using IntelliBlog.Application.Interfaces;
using IntelliBlog.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace IntelliBlog.IntegrationTests.UnitOfWork;

public class UnitOfWorkFixture : FixtureBase, IDisposable
{
    public UnitOfWorkFixture() : base() { }

    public void Dispose()
    {
    }

    public IUnitOfWork GetUnitOfWork() => GetServiceProvider().GetService<IUnitOfWork>()!;
}
