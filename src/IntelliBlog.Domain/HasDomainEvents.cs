using System.ComponentModel.DataAnnotations.Schema;

namespace Blogging.Domain;

public abstract class HasDomainEvents
{
    private List<INotification> _domainEvents = new();
    [NotMapped]
    public IEnumerable<INotification> DomainEvents => _domainEvents.AsReadOnly();
    
    protected void RegisterDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
}
