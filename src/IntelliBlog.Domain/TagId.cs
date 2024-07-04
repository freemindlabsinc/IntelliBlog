namespace IntelliBlog.Domain;

public readonly record struct TagId(int Value)
{
    public static TagId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<TagId, int>.Serialize(Value);
    public static TagId? TryParse(string? value) => StrongIdHelper<TagId, int>.Deserialize(value);
}
