namespace Blogging.Domain.Aggregates.Sources;

public static class SourceExtensions
{
    public static void AddTags(this Source source, string[] tags)
    {
        foreach (var tag in tags)
        {
            source.AddTag(tag);
        }
    }

    public static void RemoveTags(this Source source, string[] tags)
    {
        foreach (var tag in tags)
        {
            var sourceTag = source.Tags.FirstOrDefault(t => t.Name == tag);
            if (sourceTag != null)
            {
                source.RemoveTag(sourceTag);
            }
        }
    }
}
