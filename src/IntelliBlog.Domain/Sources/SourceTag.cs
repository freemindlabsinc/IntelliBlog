namespace IntelliBlog.Domain.Sources;

public class SourceTag : Tag
{
    public static SourceTag CreateNew(string name, string? description) 
    {
        var tag = new SourceTag();
        tag.UpdateName(name);
        tag.UpdateDescription(description);

        return tag;
    }

    public Source Source { get; private set; } = default!;

    private SourceTag() { } // For Entity Framework
}
