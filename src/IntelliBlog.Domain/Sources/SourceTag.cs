namespace IntelliBlog.Domain.Sources;

public class SourceTag : Tag
{
    internal static SourceTag CreateNew(string name)
        => new SourceTag(name);

    public Source Source { get; private set; } = default!;

    private SourceTag(string name) 
        : base(name)
    {
        
    }
}
