using System.Transactions;

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
    public bool IsOnline { get; private set; }
    public ISet<string> Tags { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public int AddTags(params string[] tags)
    {
        var result = 0;
        var goodTags = tags.Select(tag => Guard.Against.NullOrWhiteSpace(tag, nameof(tag)));

        foreach (var item in goodTags)
        {
            if (Tags.Add(item)) result++;            
        }

        if (result > 0) RaiseEvent(new Events.BlogUpdated(this, nameof(Tags)));

        return result;
    }

    public int RemoveTags(params string[] tags)
    {
        var result = 0;
        foreach (var tag in tags)
        {
            if (Tags.Remove(tag)) result++;            
        }

        if (result > 0) RaiseEvent(new Events.BlogUpdated(this, nameof(Tags)));

        return result;
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

    public bool GoOnline()
    {
        if (IsOnline) return false;

        IsOnline = true;

        RaiseEvent(new Events.BlogUpdated(this, nameof(IsOnline)));
        RaiseEvent(new Events.BlogOnline(this));

        return true;
    }

    public bool GoOffline()
    {
        if (IsOnline == false) return false;

        IsOnline = false;

        RaiseEvent(new Events.BlogUpdated(this, nameof(IsOnline)));
        RaiseEvent(new Events.BlogOffline(this));

        return true;
    }

    public void UpdateImage(string? image)
    {
        if (image == Image) return;

        Image = image;

        RaiseEvent(new Events.BlogUpdated(this, nameof(Image)));
    }

    //private Blog() { } // For Entity Framework
}
