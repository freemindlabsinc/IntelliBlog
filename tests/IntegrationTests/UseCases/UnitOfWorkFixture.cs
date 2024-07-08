﻿using Blogging.Domain.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blogging.IntegrationTests.UseCases;

public class UnitOfWorkFixture : FixtureBase, IDisposable
{
    public UnitOfWorkFixture() : base() { }

    public void Dispose()
    {
    }

    public IUnitOfWork Uow => GetServiceProvider().GetService<IUnitOfWork>()!;
    public ISender Sender => GetServiceProvider().GetService<ISender>()!;
}