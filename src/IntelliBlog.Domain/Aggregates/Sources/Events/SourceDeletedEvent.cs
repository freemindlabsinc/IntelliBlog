namespace Blogging.Domain.Aggregates.Sources.Events;

public readonly record struct SourceDeletedEvent(Source Sender) : INotification;
