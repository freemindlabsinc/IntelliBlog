namespace IntelliBlog.Domain.Aggregates.Blogs;
public sealed class Blog : TrackedEntity<BlogId>, IAggregateRoot
{
    public static Blog CreateNew(
        string name,
        string? description = default,
        string? smallImage = default,
        string? image = default,
        BlogStatus status = default,
        string? notes = default,
        BlogId id = default)
    {
        var blog = new Blog();
        blog.Id = id; // Once-setter
        blog.UpdateName(name);
        blog.UpdateDescription(description);
        blog.UpdateSmallImage(smallImage);
        blog.UpdateImage(image);
        blog.ChangeStatus(status);
        blog.UpdateNotes(notes);

        return blog;
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Notes { get; private set; }
    // TODO: Make Image+SmallImage a ValueObject
    public string? Image { get; private set; }
    public string? SmallImage { get; private set; }
    public BlogStatus Status { get; private set; }

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

    private Blog() { } // For Entity Framework
}
