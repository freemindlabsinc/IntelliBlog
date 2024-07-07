namespace IntelliBlog.Domain.Aggregates.Sources.Events;

public readonly record struct SourceCreatedEvent(Source Sender) : INotification;
