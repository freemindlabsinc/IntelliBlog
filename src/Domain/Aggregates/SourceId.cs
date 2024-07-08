namespace Blogging.Domain.Aggregates;

public readonly record struct SourceId(int Value)
{
    public static SourceId Empty { get; } = default;
    
    //public static implicit operator int(SourceId id) => id.Value;
    public static implicit operator SourceId(int id) => new SourceId(id);
}
