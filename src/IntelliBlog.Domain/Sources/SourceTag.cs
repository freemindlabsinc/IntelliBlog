namespace IntelliBlog.Domain.Sources;

public class SourceTag : Entity<TagId>
{
    internal static SourceTag CreateNew(string name)
        => new SourceTag(name);

    public Source Source { get; private set; } = default!;
    public string Name { get; private set; } = default!;

    private SourceTag(string name) 
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }
}
