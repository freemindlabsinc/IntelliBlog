using API.Endpoints.Sources;
using Ardalis.SharedKernel;

namespace API.Endpoints.Sources.List;

/// <summary>
/// Returns a list of articles according to the specified parameters.
/// </summary>
public sealed class ListSourcesRequest : IQuery<ListSourcesResponse>
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

    
    internal class ListSourcesRequestValidator : Validator<ListSourcesRequest>
    {
        public ListSourcesRequestValidator()
        {
            RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
            RuleFor(x => x.Take).GreaterThanOrEqualTo(1).When(x => x.Take.HasValue);
            RuleFor(x => x.Filter).NotEmpty().When(x => x.Filter != null);
        }
    }
}
