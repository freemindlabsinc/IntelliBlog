using Blogging.Domain.Aggregates.Articles;

namespace Application.UseCases.Articles.List;

// write the handler for the query  
public class ListArticlesQueryHandler(IRepository<Article> _repository) 
    : IQueryHandler<ListArticlesQuery, Result<IEnumerable<ArticleDTO>>>
{    
    public async Task<Result<IEnumerable<ArticleDTO>>> Handle(ListArticlesQuery query, CancellationToken cancellationToken)
    {
        var spec = new PagedArticlesSpec(query.Skip, query.Take, PagedArticlesSpec.ArticleIncludes.Tags);

        List<Article> articles = await _repository.ListAsync(spec, cancellationToken);


        var articleDTOs = articles.Select(a => new ArticleDTO(
            a.Id.Value,
            a.Title,
            "Author",
            a.Created,
            a.LastModified,
            a.Tags.Select(t => t.Name)));

        return Result<IEnumerable<ArticleDTO>>.Success(articleDTOs);
    }
}
