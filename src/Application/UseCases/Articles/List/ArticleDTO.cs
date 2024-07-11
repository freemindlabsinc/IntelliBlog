namespace Application.UseCases.Articles.List;

public readonly record struct ArticleDTO(
    int Id, 
    string Title, 
    string? Description, 
    DateTime CreatedOn, 
    DateTime? LastModifiedOn, 
    IEnumerable<string> Tags);
