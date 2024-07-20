namespace Blogging.Domain.Blogs;
public sealed class Blog : TrackedEntity<int>, IAggregateRoot
{
    public static Blog CreateNew(
        string name,
        string? description = default,
        string? smallImage = default,
        string? image = default,
        string? notes = default)
    {
        var blog = new Blog();
        blog.UpdateName(name);
        blog.UpdateDescription(description);
        blog.UpdateSmallImage(smallImage);
        blog.UpdateImage(image);
        blog.UpdateNotes(notes);

        //blog.ClearDomainEvents();
        blog.RaiseEvent(new BlogCreatedEvent(blog));
        return blog;
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Notes { get; private set; }
    // TODO: Make Image+SmallImage a ValueObject
    public string? Image { get; private set; }
    public string? SmallImage { get; private set; }
    public bool IsPublished { get; private set; }

    public void MarkDeleted()
    {
        RaiseEvent(new BlogDeletedEvent(this));
    }
    public void UpdateName(string name)
    {
        if (name == this.Name) return;

        Guard.Against.NullOrWhiteSpace(name, nameof(name));

        Name = name;

        RaiseEvent(new BlogUpdatedEvent(this, nameof(Name)));
    }

    public void UpdateDescription(string? description)
    {
        if (description == this.Description) return;

        Description = description;

        RaiseEvent(new BlogUpdatedEvent(this, nameof(Description)));
    }

    public void UpdateNotes(string? notes)
    {
        if (notes == this.Notes) return;

        Notes = notes;

        RaiseEvent(new BlogUpdatedEvent(this, nameof(Notes)));
    }

    public void Publish()
    {
        if (this.IsPublished) return;

        IsPublished = true;

        RaiseEvent(new BlogUpdatedEvent(this, nameof(IsPublished)));
    }

    public void Unpublish()
    {
        if (this.IsPublished == false) return;

        IsPublished = false;

        RaiseEvent(new BlogUpdatedEvent(this, nameof(IsPublished)));
    }

    public void UpdateImage(string? image)
    {
        if (image == this.Image) return;

        Image = image;

        RaiseEvent(new BlogUpdatedEvent(this, nameof(Image)));
    }

    public void UpdateSmallImage(string? smallImage)
    {
        if (smallImage == this.SmallImage) return;

        SmallImage = smallImage;

        RaiseEvent(new BlogUpdatedEvent(this, nameof(SmallImage)));
    }

    private Blog() { } // For Entity Framework
}
