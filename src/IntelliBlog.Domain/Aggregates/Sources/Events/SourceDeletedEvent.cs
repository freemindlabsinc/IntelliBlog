namespace IntelliBlog.Domain.Aggregates.Sources.Events;
public class SourceDeletedEvent : DomainEventBase
{
    public SourceId SourceId { get; init; }

    public SourceDeletedEvent(SourceId sourceId)
    {
        SourceId = sourceId;
    }
}
