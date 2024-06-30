using FreeMindLabs.IntelliBlog.Core.Domain.Article.Events;
using FreeMindLabs.IntelliBlog.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace FreeMindLabs.IntelliBlog.Core.Domain.Article.Handlers;

internal class ArticleDeletedHandler(ILogger<ArticleDeletedHandler> logger, IEmailSender emailSender) 
    : INotificationHandler<ArticleDeletedEvent>
{
    public async Task Handle(ArticleDeletedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling Article Deleted event for {articleId}", domainEvent.ArticleId);

        await emailSender.SendEmailAsync("to@test.com",
                                         "from@test.com",
                                         "Contributor Deleted",
                                         $"Contributor with id {domainEvent.ArticleId} was deleted.");
    }
}
