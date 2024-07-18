using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace Blogging.Domain;

public abstract class HasDomainEvents
{
    [GraphQLIgnore]
    private List<INotification> _domainEvents = new();
    
    [NotMapped]
    [GraphQLIgnore]
    public IEnumerable<INotification> DomainEvents => _domainEvents.AsReadOnly();

    [GraphQLIgnore]
    protected void RegisterDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);
    
    [GraphQLIgnore]
    internal void ClearDomainEvents() => _domainEvents.Clear();
}
