using IntelliBlog.Domain.Blogs;
using IntelliBlog.Domain.Sources;

namespace IntelliBlog.Domain.Articles;

public sealed class Article : TrackedEntity<ArticleId>, IAggregateRoot
{
    public static Article CreateNew(
        string title,        
        string? description = default,
        string? text = default) 

        => new Article()
            .UpdateTitle(title)
            .UpdateDescription(description)
            .UpdateText(text);
        
    
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Text { get; private set; }
    
    public IReadOnlyCollection<ArticleTag> Tags => _tags.AsReadOnly();
    public IReadOnlyCollection<ArticleSource> Sources => _sources.AsReadOnly();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
    public IReadOnlyCollection<BlogArticle> Blogs => _blogs.AsReadOnly();

    public Article UpdateTitle(string title)
    {
        Guard.Against.NullOrWhiteSpace(title, nameof(title));
        this.Title = title;        
        return this;
    }

    public Article UpdateDescription(string? description)
    {
        this.Description = description;
        return this;
    }

    public Article UpdateText(string? text)
    {
        this.Text = text;
        return this;
    }

    public Article AddTag(ArticleTag tag)
    {

        _tags.Add(tag);
        return this;
    }

    public Article AddSources(params SourceId[] sourceIds)
    {
        foreach (var _ in sourceIds)
            _sources.Add(ArticleSource.CreateNew(this.Id, _));

        // TODO: make distinct
        
        return this;
    }

    private readonly List<ArticleTag> _tags = new List<ArticleTag>();
    private readonly List<ArticleSource> _sources = new List<ArticleSource>();
    private readonly List<Comment> _comments = new List<Comment>();
    private readonly List<BlogArticle> _blogs = new List<BlogArticle>();

    private Article() { } // For Entity Framework
}
