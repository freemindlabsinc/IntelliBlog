namespace Blogging.Domain.Aggregates.Sources;

public class SourceTag : Tag
{
    internal static SourceTag CreateNew(string name, string? description) 
    {
        var tag = new SourceTag();
        tag.UpdateName(name);
        tag.UpdateDescription(description);

        return tag;
    }
    
    private SourceTag() { } // For Entity Framework
}
