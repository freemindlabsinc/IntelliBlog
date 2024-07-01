namespace IntelliBlog.Domain;

public class TrackedEntity<TId>(): EntityBase<TId>
    where TId : struct, IEquatable<TId>
{
    public DateTime Created { get; private set; } = DateTime.UtcNow;

    public string CreatedBy { get; private set; } = string.Empty;

    public DateTime? LastModified { get; private set; }    

    public string? LastModifiedBy { get; private set; }

    public void SetCreated(string createdBy)
    {
        Guard.Against.Empty(createdBy, nameof(createdBy));
        
        if (this.CreatedBy != string.Empty)
            // ChatGPT: InvalidOperationException is typically used to indicate that a method call is invalid for the object's current state.
            throw new InvalidOperationException($"{nameof(this.CreatedBy)} cannot be updated once set.");
        
        CreatedBy = createdBy;
    }

    public void UpdateLastModified(string lastModifiedBy)
    {
        Guard.Against.NullOrWhiteSpace(lastModifiedBy, nameof(lastModifiedBy));

        LastModifiedBy = lastModifiedBy;
        LastModified = DateTime.UtcNow;
    }    
}
