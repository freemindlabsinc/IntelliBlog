using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Contributor;
using IntelliBlog.Domain.Contributor.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IntelliBlog.Application.Services;

/// <summary>
/// This is here mainly so there's an example of a domain service
/// and also to demonstrate how to fire domain events from a service.
/// </summary>
/// <param name="_repository"></param>
/// <param name="_mediator"></param>
/// <param name="_logger"></param>
public class ContributorDeleteService(IRepository<Contributor> _repository,
  IMediator _mediator,
  ILogger<ContributorDeleteService> _logger) : IContributorDeleteService
{
    public async Task<Result> DeleteContributor(int contributorId)
    {
        _logger.LogInformation("Deleting Contributor {contributorId}", contributorId);
        Contributor? aggregateToDelete = await _repository.GetByIdAsync(contributorId);
        if (aggregateToDelete == null) return Result.NotFound();

        await _repository.DeleteAsync(aggregateToDelete);
        var domainEvent = new ContributorDeletedEvent(contributorId);
        await _mediator.Publish(domainEvent);
        return Result.Success();
    }

   
}
