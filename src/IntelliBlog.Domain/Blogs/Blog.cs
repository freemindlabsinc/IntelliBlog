using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Domain.Blogs;

public sealed class Blog : TrackedEntity<BlogId>, IAggregateRoot
{
    public static Blog CreateNew(
        string name, 
        string? description = default, 
        string? smallImage = default, 
        string? image = default)
    {
        var blog = new Blog();
        blog.UpdateName(name);
        blog.UpdateDescription(description);
        blog.UpdateSmallImage(smallImage);
        blog.UpdateImage(image);
        return blog;
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Notes { get; private set; }
    public string? Image { get; private set; }
    public string? SmallImage { get; private set; }
    public BlogStatus Status { get; private set; } = BlogStatus.Published; // TODO: Convert to Ardalis SmartEnum

    public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
    
    public void UpdateName(string name)
    {
        Guard.Against.NullOrWhiteSpace(name, nameof(name));

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

    private readonly List<Article> _articles = new List<Article>();

    private Blog() { } // For Entity Framework
}
