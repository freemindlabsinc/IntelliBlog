namespace Blogging.Domain.Base;

public interface IDomainEventContainer
{
    IEnumerable<INotification> DomainEvents { get; }

    void ClearDomainEvents();
}
