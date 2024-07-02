namespace IntelliBlog.API.Endpoints.Sources;

public readonly record struct CreateSourceRequest(
    string Name,
    string? Url,
    string? Description,
    string[]? Tags);
