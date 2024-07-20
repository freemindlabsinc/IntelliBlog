namespace Blogging.Domain.Base;

public abstract class DomainEventProducer
{
    private List<INotification> _domainEvents = new();

    // TODO: see if I can handle NotMapped in the EF type configurations
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public IEnumerable<INotification> DomainEvents => _domainEvents.AsReadOnly();

    protected void RaiseEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);
}
