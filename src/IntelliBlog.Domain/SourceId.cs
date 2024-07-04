namespace IntelliBlog.Domain;

public readonly record struct SourceId(int Value)
{
    public static SourceId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<SourceId, int>.Serialize(Value);
    public static SourceId? TryParse(string? value) => StrongIdHelper<SourceId, int>.Deserialize(value);

    public static implicit operator int(SourceId id) => id.Value;
    public static implicit operator SourceId(int id) => new SourceId(id);
}
