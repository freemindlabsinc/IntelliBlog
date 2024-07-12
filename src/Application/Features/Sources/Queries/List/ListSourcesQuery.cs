namespace Application.Features.Sources.Queries.List;

public readonly partial record struct ListSourcesQuery(
    int? Skip = 0,
    int? Take = 10,
    string? filter = default) : IQuery<Result<IEnumerable<SourceDTO>>>
{
    internal class ListSourcesQueryValidator : AbstractValidator<ListSourcesQuery>
    {
        public ListSourcesQueryValidator()
        {
            RuleFor(x => x.Skip).GreaterThanOrEqualTo(0).When(x => x.Skip.HasValue);
            RuleFor(x => x.Take).GreaterThan(0).When(x => x.Take.HasValue);
        }
    }
}
