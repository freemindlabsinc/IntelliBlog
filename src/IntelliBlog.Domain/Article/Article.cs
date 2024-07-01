namespace IntelliBlog.Domain.Article;

public readonly record struct ArticleId(int Value)
{
    public static ArticleId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<ArticleId, int>.Serialize(Value);
    public static ArticleId? TryParse(string? value) => StrongIdHelper<ArticleId, int>.Deserialize(value);
}

public class Article : TrackedEntity<ArticleId>, IAggregateRoot
{
    public static Article CreateNew(
        string title,
        string? description = default,
        string? content = default)
    {
        var result = new Article(title);
        result.Description = description;
        result.Content = content;        

        return result;
    }
    
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Content { get; private set; }
    public List<Tag> Tags { get; private set; } = new List<Tag>();

    public Article AddTags(params string[] tags)
    { 
        this.Tags.AddRange(Tag.CreateMany(tags));
        return this;
    }

    public Article UpdateTitle(string title)
    {
        Guard.Against.NullOrWhiteSpace(title, nameof(title));
        this.Title = title;        
        return this;
    }

    public Article UpdateDescription(string description)
    {
        this.Description = description;
        return this;
    }

    public Article UpdateContent(string content)
    {
        this.Content = content;
        return this;
    }

    // For EF Core
    private Article(string title) 
    { 
        UpdateTitle(title);
    } 
}
