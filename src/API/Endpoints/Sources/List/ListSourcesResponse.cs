using API.Endpoints.Blogs.List;

namespace API.Endpoints.Sources.List;

/// <summary>
/// The response to the <see cref="ListBlogsRequest" />.
/// </summary>
/// <param name="Sources">The list of sources.</param>
public readonly record struct ListSourcesResponse(
     IEnumerable<SourceResult> Sources);
