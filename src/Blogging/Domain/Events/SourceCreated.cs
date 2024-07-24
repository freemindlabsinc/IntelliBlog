namespace Blogging.Domain.Events;

public readonly record struct SourceCreated(Source Sender) : INotification;
