namespace Blogging.Domain.Base;

public abstract class DomainEventProducer : IDomainEventContainer
{
    private List<INotification> _domainEvents = new();

    // TODO: see if I can handle NotMapped in the EF type configurations
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    IEnumerable<INotification> IDomainEventContainer.DomainEvents => _domainEvents.AsReadOnly();

    void IDomainEventContainer.ClearDomainEvents()
        => _domainEvents.Clear();    

    protected void RaiseEvent(INotification domainEvent) 
        => _domainEvents.Add(domainEvent);

}
