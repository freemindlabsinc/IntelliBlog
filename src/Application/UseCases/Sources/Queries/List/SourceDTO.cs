namespace Application.UseCases.Sources.Queries.List;

public readonly record struct SourceDTO(
    int Id,
    string Title,
    string? Description,
    DateTime CreatedOn,
    DateTime? LastModifiedOn);
