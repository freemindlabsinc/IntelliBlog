using Application.Interfaces;
using Blogging.Domain.Aggregates.Articles.Events;
using Microsoft.Extensions.Logging;

namespace Application.EventHandlers;

internal class ArticleDeletedHandler(ILogger<ArticleDeletedHandler> logger, IEmailSender emailSender) 
    : INotificationHandler<ArticleDeletedEvent>
{
    public async Task Handle(ArticleDeletedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling Article Deleted event for {articleId}", domainEvent.Sender.Id);

        await emailSender.SendEmailAsync("to@test.com",
                                         "from@test.com",
                                         "Contributor Deleted",
                                         $"Contributor with id {domainEvent.Sender.Id} was deleted.");
    }
}
