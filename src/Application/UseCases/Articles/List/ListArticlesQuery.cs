namespace Application.UseCases.Articles.List;

public readonly record struct ListArticlesQuery(
    int? Skip = 0,
    int? Take = 10) 
    : IQuery<Result<IEnumerable<ArticleDTO>>>;
