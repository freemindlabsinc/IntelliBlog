namespace IntelliBlog.API.Application.UseCases.Articles.List;

public interface IListArticlesQueryService
{
    Task<IEnumerable<ArticleDTO>> ListAsync(int? skip, int? take);
}
