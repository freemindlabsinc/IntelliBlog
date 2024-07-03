namespace IntelliBlog.Domain.Articles;

public class Article : TrackedEntity<ArticleId>, IAggregateRoot
{
    public static Article CreateNew(
        string title,
        string? description = default,
        string? text = default)
    {
        var result = new Article(title);
        result.Description = description;
        result.Text = text;        

        return result;
    }
    
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Text { get; private set; }
    public List<ArticleTag> Tags { get; private set; } = new List<ArticleTag>();
    public List<ArticleSource> Sources { get; private set; } = new List<ArticleSource>();

    
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
        this.Text = content;
        return this;
    }

    // For EF Core
    private Article(string title) 
    { 
        UpdateTitle(title);
    } 
}
