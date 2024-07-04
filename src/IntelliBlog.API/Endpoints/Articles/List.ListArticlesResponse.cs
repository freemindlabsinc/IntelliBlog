using IntelliBlog.API.Application.UseCases.Articles;

namespace IntelliBlog.API.Endpoints.Articles;

public readonly record struct ListArticlesResponse(
     IEnumerable<ArticleDTO> Articles);
