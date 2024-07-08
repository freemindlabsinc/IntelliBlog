namespace Blogging.Domain.Aggregates.Sources.Events;

public readonly record struct SourceUpdatedEvent(Source Sender, string Property) : INotification;
