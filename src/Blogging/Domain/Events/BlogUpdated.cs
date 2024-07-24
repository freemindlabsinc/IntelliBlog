namespace Blogging.Domain.Events;
public readonly record struct BlogUpdated(Blog Sender, string Property) : INotification;
