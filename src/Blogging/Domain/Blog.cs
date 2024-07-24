namespace Blogging.Domain;

public sealed class Blog : TrackedEntity<int>, IAggregateRoot
{
    private IList<string> _tags = new List<string>();

    internal Blog() { /* For HotChocolate */ } 

    public Blog(
        string name,
        string? description = default,
        string? image = default,
        string? notes = default,
        string[]? tags = default)
    {
        this.Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        this.Description = description;
        this.Notes = notes;
        this.Image = image;        
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Notes { get; private set; }
    public string? Image { get; private set; }
    public bool IsOnline { get; private set; }
    public IEnumerable<string> Tags { get { return _tags.ToList(); } private set { /* For EF8 */ } }

    StringComparer TagComparer = StringComparer.OrdinalIgnoreCase;

    public void AddTags(params string[] tags)
    {        
        _tags = tags
            .Select(tag => Guard.Against.NullOrWhiteSpace(tag, nameof(tag)))
            .Union(_tags)
            .Distinct(TagComparer)
            .ToList();

        RaiseEvent(new Events.BlogUpdated(this, nameof(Tags)));
    }

    public void RemoveTags(params string[] tags)
    {
        _tags = _tags
            .Except(tags)
            .ToList();
        
        RaiseEvent(new Events.BlogUpdated(this, nameof(Tags)));
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

    public void GoOnline()
    {
        if (IsOnline) return;

        IsOnline = true;

        RaiseEvent(new Events.BlogUpdated(this, nameof(IsOnline)));
        RaiseEvent(new Events.BlogOnline(this));
    }


    public void GoOffline()
    {
        if (IsOnline == false) return;

        IsOnline = false;

        RaiseEvent(new Events.BlogUpdated(this, nameof(IsOnline)));
        RaiseEvent(new Events.BlogOffline(this));
    }

    public void UpdateImage(string? image)
    {
        if (image == Image) return;

        Image = image;

        RaiseEvent(new Events.BlogUpdated(this, nameof(Image)));
    }
}
