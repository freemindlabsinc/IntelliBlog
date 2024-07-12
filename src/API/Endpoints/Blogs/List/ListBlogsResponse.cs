using Application.Features.Blogs.Queries.List;

namespace API.Endpoints.Blogs.List;

/// <summary>
/// The response to the <see cref="ListBlogsQuery" />.
/// </summary>
/// <param name="Articles">The list of blog.</param>
public readonly record struct ListBlogsResponse(
     IEnumerable<BlogResult> Articles);
