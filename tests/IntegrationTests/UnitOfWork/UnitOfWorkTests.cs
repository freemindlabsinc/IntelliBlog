﻿using Xunit.Abstractions;

namespace Blogging.IntegrationTests.UnitOfWork;

// TODO: refactor!!!
// This should probably not get a UOW in the fixture... it shuold create
// it itself. This file tests the UnitOfWork class therefore it needs to have
// full control of it. REFACTOR

public class UnitOfWorkTests
    //: IClassFixture<UnitOfWorkFixture>
{
    public UnitOfWorkTests(ITestOutputHelper outputHelper)
    {
        // AppDbContext _dbContext,
        // IMediator _mediator
    }

    //[Fact]
    //public void GetRepositoryT_returns_IRepositoryT()
    //{
    //    
    //    throw new NotImplementedException();
    //    //var uow = new UnitOfWork();
    //    //
    //    //var repo1 = _fixture.Uow.GetRepository<Blog>();
    //    //repo1.Should().BeAssignableTo<IRepository<Blog>>();
    //    //
    //    //var repo2 = _fixture.Uow.GetRepository<Article>();
    //    //repo2.Should().BeAssignableTo<IRepository<Article>>();
    //}
}
