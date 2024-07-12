using Ardalis.SharedKernel;

namespace API.Endpoints.Blogs.List;

/// <summary>
/// Returns a list of articles according to the specified parameters.
/// </summary>
public sealed class ListBlogsRequest() : IQuery<ListBlogsResponse>
{
    /// <summary>
    /// The number of items to skip.
    /// </summary>
    [QueryParam]
    public int? Skip { get; init; }

    /// <summary>
    /// The number of items to return.
    /// </summary>    
    [QueryParam]
    public int? Take { get; init; }

    /// <summary>
    /// An optional filter to apply to the items.
    /// </summary>
    [QueryParam]
    public string? Filter { get; init; }

    internal class ListArticlesRequestValidator : Validator<ListBlogsRequest>
    {
        public ListArticlesRequestValidator()
        {
            RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
            RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
            RuleFor(x => x.Filter).NotEmpty().When(x => x.Filter != null);
        }
    }

}
