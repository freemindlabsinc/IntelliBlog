namespace IntelliBlog.Domain;

public abstract class Tag : Entity<TagId>
{    
    public string Name { get; private set; } = default!;

    protected Tag(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }
}
