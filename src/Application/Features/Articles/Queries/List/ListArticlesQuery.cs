﻿using Blogging.Domain.Aggregates.Articles;

namespace Application.Features.Articles.Queries.List;

public readonly record struct ListArticlesQuery(
    int? Skip = 0,
    int? Take = 10, 
    string? Filter = default)
    : IQuery<Result<IEnumerable<ArticleDTO>>>;

public class ListArticlesQueryHandler(IRepository<Article> _repository)
    : IQueryHandler<ListArticlesQuery, Result<IEnumerable<ArticleDTO>>>
{
    public async Task<Result<IEnumerable<ArticleDTO>>> Handle(ListArticlesQuery query, CancellationToken cancellationToken)
    {
        var spec = new PagedArticlesSpec(query.Skip, query.Take, query.Filter, PagedArticlesSpec.ArticleIncludes.Tags);

        var articles = await _repository.ListAsync(spec, cancellationToken);

        var articleDTOs = articles.Select(a => new ArticleDTO(
            a.Id,
            a.Title,
            "Author",
            a.CreatedOn,
            a.LastModifiedOn,
            a.Tags.Select(t => t.Name)));

        return Result<IEnumerable<ArticleDTO>>.Success(articleDTOs);
    }
}


public class ListArticlesQueryValidator : AbstractValidator<ListArticlesQuery>
{
    public ListArticlesQueryValidator()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Take).GreaterThanOrEqualTo(1);
    }
}
