namespace Blogging.Domain;

public sealed class Blog : TrackedEntity<int>, IAggregateRoot
{
    public Blog(
        string name,
        string? description = default,
        string? image = default,
        string? notes = default)
    {
        UpdateName(name);
        UpdateDescription(description);
        UpdateNotes(notes);
        UpdateImage(image);
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Notes { get; private set; }
    public string? Image { get; private set; }
    public bool IsPublished { get; private set; }
    public ISet<string> Tags { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public void AddTags(string tag)
    {
        Guard.Against.NullOrWhiteSpace(tag, nameof(tag));

        if (Tags.Add(tag)) RaiseEvent(new Events.BlogUpdated(this, nameof(Tags)));
    }

    public void RemoveTag(string tag)
    {
        Guard.Against.NullOrWhiteSpace(tag, nameof(tag));

        if (Tags.Remove(tag)) RaiseEvent(new Events.BlogUpdated(this, nameof(Tags)));
    }

    public void UpdateName(string name)
    {
        if (name == Name) return;        

        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));

        RaiseEvent(new Events.BlogUpdated(this, nameof(Name)));
    }

    public void UpdateDescription(string? description)
    {
        if (description == Description) return;

        Description = description;

        RaiseEvent(new Events.BlogUpdated(this, nameof(Description)));
    }

    public void UpdateNotes(string? notes)
    {
        if (notes == Notes) return;

        Notes = notes;

        RaiseEvent(new Events.BlogUpdated(this, nameof(Notes)));
    }

    public void Publish()
    {
        if (IsPublished) return;

        IsPublished = true;

        RaiseEvent(new Events.BlogPlublished(this));
        RaiseEvent(new Events.BlogUpdated(this, nameof(IsPublished)));
    }

    public void Unpublish()
    {
        if (IsPublished == false) return;

        IsPublished = false;

        RaiseEvent(new Events.BlogPlublished(this));
        RaiseEvent(new Events.BlogUpdated(this, nameof(IsPublished)));
    }

    public void UpdateImage(string? image)
    {
        if (image == Image) return;

        Image = image;

        RaiseEvent(new Events.BlogUpdated(this, nameof(Image)));
    }

    //private Blog() { } // For Entity Framework
}
