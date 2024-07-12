namespace Application.Features.Sources.Queries.List;

public readonly record struct SourceDTO(
    int Id,
    string Name,
    string? Url,
    string? Description,
    DateTime CreatedOn,
    DateTime? LastModifiedOn);
