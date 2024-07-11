namespace API.Endpoints.Articles.List;

/// <summary>
/// The response to the <see cref="ListArticlesRequest" />.
/// </summary>
/// <param name="Articles">The list of articles.</param>
public readonly record struct ListArticlesResponse(
     IEnumerable<ArticleResult> Articles);
