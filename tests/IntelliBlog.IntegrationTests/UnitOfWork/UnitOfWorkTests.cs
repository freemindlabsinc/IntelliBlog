using Ardalis.SharedKernel;
using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Blogs;
using Xunit.Abstractions;

namespace IntelliBlog.IntegrationTests.UnitOfWork;

public class UnitOfWorkTests
: IClassFixture<UnitOfWorkFixture>
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly UnitOfWorkFixture _fixture;

    public UnitOfWorkTests(UnitOfWorkFixture fixture, ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _fixture = fixture;
        _fixture.SetTestOutputHelper(_outputHelper);
    }

    [Fact]
    public void GetRepositoryT_returns_IRepositoryT()
    {
        var uow = _fixture.GetUnitOfWork();
        var repo1 = uow.GetRepository<Blog>();
        repo1.Should().BeAssignableTo<IRepository<Blog>>();

        var repo2 = uow.GetRepository<Article>();
        repo1.Should().BeAssignableTo<IRepository<Article>>();
    }

    [Fact]
    public void Ensure_domain_events_are_published()
    { 
        
    }
    
}
