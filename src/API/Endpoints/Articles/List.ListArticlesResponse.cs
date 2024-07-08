using Blogging.API.Application.UseCases.Articles;

namespace Blogging.API.Endpoints.Articles;

public readonly record struct ListArticlesResponse(
     IEnumerable<ArticleDTO> Articles);
