namespace Blogging.Domain.Events;
public readonly record struct BlogCreated(Blog Sender) : INotification;


public record EntityCreatedEvent<T>(T Entity) : INotification where T : IAggregateRoot;

public record EntityDeletedEvent<T>(T Entity) : INotification where T : IAggregateRoot;

public record EntityUpdatedEvent<T>(T Entity) : INotification where T : IAggregateRoot;
