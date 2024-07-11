using FastEndpoints;

namespace API.Endpoints.Articles.List;

/// <summary>
/// Returns a list of articles according to the specified parameters.
/// </summary>
public sealed class ListArticlesRequest() : IQuery<ListArticlesResponse>
{
    /// <summary>
    /// The number of articles to skip.
    /// </summary>
    [QueryParam]
    public int? Skip { get; init; }

    /// <summary>
    /// The number of articles to return.
    /// </summary>    
    [QueryParam]
    public int? Take { get; init; }

    /// <summary>
    /// An optional filter to apply to the articles.
    /// </summary>
    [QueryParam]
    public string? Filter { get; init; }
}
