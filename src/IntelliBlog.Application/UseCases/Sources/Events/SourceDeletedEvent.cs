namespace IntelliBlog.Domain.Aggregates.Sources.Events;
public readonly record struct SourceDeletedEvent(SourceId sourceId) : INotification;
