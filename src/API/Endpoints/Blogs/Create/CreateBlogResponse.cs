namespace API.Endpoints.Blogs.Create;

/// <summary>
/// The response to <see cref="CreateBlogRequest"/>.
/// </summary>
/// <param name="BlogId">The id of the created blog.</param>
public readonly record struct CreateBlogResponse(
    int BlogId);
