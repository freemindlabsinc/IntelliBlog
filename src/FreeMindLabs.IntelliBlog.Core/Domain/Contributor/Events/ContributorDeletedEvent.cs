﻿using Ardalis.SharedKernel;

namespace FreeMindLabs.IntelliBlog.Core.Domain.Contributor.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class ContributorDeletedEvent(int contributorId) : DomainEventBase
{
    public int ContributorId { get; init; } = contributorId;
}
