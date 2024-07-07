namespace IntelliBlog.Domain;

public abstract class Tag : Entity<int>
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;

    public void UpdateName(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));        
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    protected Tag() { } // For Entity Framework
}
