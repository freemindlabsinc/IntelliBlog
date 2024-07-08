using Application.UseCases.Articles.List;

namespace Blogging.API.Endpoints.Articles;

public readonly record struct ListArticlesResponse(
     IEnumerable<ArticleDTO> Articles);
