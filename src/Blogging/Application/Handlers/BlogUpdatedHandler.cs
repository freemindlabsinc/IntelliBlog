using Blogging.Domain.Events;

namespace Blogging.Application.Handlers;
public class BlogUpdatedHandler(ILogger<BlogUpdatedHandler> _logger) 
    : INotificationHandler<EntityUpdatedEvent<Blog>>,
    INotificationHandler<EntityCreatedEvent<Blog>>,
    INotificationHandler<EntityDeletedEvent<Blog>>
{
    public Task Handle(EntityUpdatedEvent<Blog> request, CancellationToken cancellationToken)
    {
        _logger.LogWarning("Blog updated: {Blog}", request.Entity);
        return Task.CompletedTask;
    }

    public Task Handle(EntityCreatedEvent<Blog> notification, CancellationToken cancellationToken)
    {
        _logger.LogWarning("Blog created: {Blog}", notification.Entity);
        return Task.CompletedTask;
    }

    public Task Handle(EntityDeletedEvent<Blog> notification, CancellationToken cancellationToken)
    {
        _logger.LogWarning("Blog deleted: {Blog}", notification.Entity);
        return Task.CompletedTask;
    }
}
