namespace API.Endpoints.Sources;

public readonly record struct SourceResult(
    string Name,
    string Url,
    DateTime CreatedAt,
    DateTime UpdatedAt);
