using IntelliBlog.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IntelliBlog.IntegrationTests.UseCases;

public class UnitOfWorkFixture : FixtureBase, IDisposable
{
    public UnitOfWorkFixture() : base() { }

    public void Dispose()
    {
    }

    public IUnitOfWork Uow => GetServiceProvider().GetService<IUnitOfWork>()!;
    public ISender Sender => GetServiceProvider().GetService<ISender>()!;
}
