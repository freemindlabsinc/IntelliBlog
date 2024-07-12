namespace Application.Features.Blogs.Queries.List;

public readonly record struct BlogDTO(
    int Id,
    string Name,
    string Description,
    DateTime CreatedOn,
    DateTime? LastModifiedOn
);
