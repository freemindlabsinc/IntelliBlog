using IntelliBlog.Domain.Articles;


namespace IntelliBlog.Domain.Blogs;

public class Blog : TrackedEntity<BlogId>, IAggregateRoot
{
    private readonly List<Article> _articles = new List<Article>();

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Notes { get; private set; }
    public string? Image { get; private set; } // TODO: convert into ValueObject URL
    public string? SmallImage { get; private set; } // TODO: convert into ValueObject URL
    public BlogStatus Status { get; private set; } = BlogStatus.Published; // TODO: Convert to Ardalis SmartEnum

    public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();

    public Blog(string name)
        : this()
    {
        UpdateName(name);
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required and cannot be empty or whitespace.", nameof(name));

        Name = name;
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public void UpdateNotes(string? notes)
    {
        Notes = notes;
    }


    public void ChangeStatus(BlogStatus status)
    {
        Status = status;
    }

    public void UpdateImage(string? image)
    {
        Image = image;
    }

    public void UpdateSmallImage(string? smallImage)
    {
        SmallImage = smallImage;
    }
    
    public void AddArticle(Article article)
    {
        _articles.Add(article);
    }

    public void RemoveArticle(Article article)
    {
        _articles.Remove(article);
    }

    protected Blog() { } // For Entity Framework

}
