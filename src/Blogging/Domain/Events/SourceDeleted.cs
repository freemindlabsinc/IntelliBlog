namespace Blogging.Domain.Events;

public readonly record struct SourceDeleted(Source Sender) : INotification;
