using Application.UseCases.Articles.List;

namespace API.Endpoints.Articles.List;

public readonly record struct ArticleResult(
    int Id,
    string Title,
    string? Description,
    DateTime CreatedOn,
    DateTime? LastModifiedOn)
{
    public static ArticleResult FromArticleDTO(ArticleDTO articleDTO)
        => new ArticleResult(
            articleDTO.Id,
            articleDTO.Title,
            articleDTO.Description,
            articleDTO.CreatedOn,
            articleDTO.LastModifiedOn);
}
