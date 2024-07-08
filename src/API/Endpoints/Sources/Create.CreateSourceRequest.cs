namespace Blogging.API.Endpoints.Sources;

public readonly record struct CreateSourceRequest(
    int BlogId,
    string Name,
    string? Url,
    string? Description,
    string[]? Tags);
