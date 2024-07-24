namespace Blogging.Domain.Events;

public readonly record struct SourceUpdated(Source Sender, string Property) : INotification;
