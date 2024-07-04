namespace IntelliBlog.Domain;

public readonly record struct SourceId(int Value)
{
    public static SourceId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<SourceId, int>.Serialize(Value);
    public static SourceId? TryParse(string? value) => StrongIdHelper<SourceId, int>.Deserialize(value);
}
