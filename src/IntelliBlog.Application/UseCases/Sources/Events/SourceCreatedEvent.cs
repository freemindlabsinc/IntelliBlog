namespace IntelliBlog.Application.UseCases.Sources.Events;

public readonly record struct SourceCreatedEvent(SourceId SourceId) : INotification;
