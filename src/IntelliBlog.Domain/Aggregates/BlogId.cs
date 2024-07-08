namespace Blogging.Domain.Aggregates;

public readonly record struct BlogId(int Value)
{
    public static BlogId Empty { get; } = default;
    
    public static implicit operator int(BlogId id) => id.Value;
    public static implicit operator BlogId(int id) => new BlogId(id);
}
