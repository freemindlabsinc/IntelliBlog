﻿using FreeMindLabs.IntelliBlog.Core.Domain.Contributor.Events;
using FreeMindLabs.IntelliBlog.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FreeMindLabs.IntelliBlog.Core.Domain.Contributor.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class ContributorDeletedHandler(ILogger<ContributorDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<ContributorDeletedEvent>
{
    public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.ContributorId);

        await emailSender.SendEmailAsync("to@test.com",
                                         "from@test.com",
                                         "Contributor Deleted",
                                         $"Contributor with id {domainEvent.ContributorId} was deleted.");
    }
}
