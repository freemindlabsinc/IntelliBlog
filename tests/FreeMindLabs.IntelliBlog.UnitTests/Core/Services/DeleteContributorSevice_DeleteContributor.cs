using Ardalis.SharedKernel;
using FreeMindLabs.IntelliBlog.Core.ContributorAggregate;
using FreeMindLabs.IntelliBlog.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace FreeMindLabs.IntelliBlog.UnitTests.Core.Services;

public class DeleteContributorService_DeleteContributor
{
  private readonly IRepository<Contributor> _repository = Substitute.For<IRepository<Contributor>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<ContributorDeleteService> _logger = Substitute.For<ILogger<ContributorDeleteService>>();

  private readonly ContributorDeleteService _service;

  public DeleteContributorService_DeleteContributor()
  {
    _service = new ContributorDeleteService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeleteContributor(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
