using Application.UseCases.Articles.List;

namespace API.Endpoints.Articles.List;

public readonly record struct ListArticlesResponse(
     IEnumerable<ArticleDTO> Articles);
