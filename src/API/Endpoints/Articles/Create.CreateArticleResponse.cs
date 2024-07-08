namespace Blogging.API.Endpoints.Articles;

/// <summary>
/// The response for the create article endpoint.
/// </summary>
/// <param name="Id">The id of the created article.</param>
public readonly record struct CreateArticleResponse(int Id);
