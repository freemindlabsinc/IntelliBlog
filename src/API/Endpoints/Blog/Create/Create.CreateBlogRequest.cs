namespace API.Endpoints.Blog.Create;

/// <summary>
/// Creates a new blog.
/// </summary>
/// <param name="Name">The name of the blog.</param>
/// <param name="Description">A description (optional).</param>
public readonly record struct CreateBlogRequest(string Name, string? Description);
