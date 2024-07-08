using Blogging.Domain.Aggregates.Articles;

namespace Blogging.API.Application.UseCases.Articles.List;

public class ListArticlesQueryHandler(IRepository<Article> _repository) 
    : IQueryHandler<ListArticlesQuery, Result<IEnumerable<ArticleDTO>>>
{
    public async Task<Result<IEnumerable<ArticleDTO>>> Handle(ListArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _repository.ListAsync();// request.Skip, request.Take);

        var result = articles.Select(a => new ArticleDTO(
            Id: a.Id.Value, 
            Title: a.Title, 
            Description: a.Description,
            Text: a.Text));

        return Result<IEnumerable<ArticleDTO>>.Success(result);
    }
}
