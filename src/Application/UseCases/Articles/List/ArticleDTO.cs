namespace Application.UseCases.Articles.List;

public record ArticleDTO(
    int Id, 
    string Title, 
    string? Description, 
    DateTime CreatedOn, 
    DateTime? LastModifiedOn, 
    IEnumerable<string> Tags);
