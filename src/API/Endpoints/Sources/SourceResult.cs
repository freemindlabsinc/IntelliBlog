namespace API.Endpoints.Sources;

public readonly record struct SourceResult(
    int Id,
    string Name,
    string? Url,
    string? Description,
    DateTime CreatedOn,
    DateTime LastModifiedOn);
