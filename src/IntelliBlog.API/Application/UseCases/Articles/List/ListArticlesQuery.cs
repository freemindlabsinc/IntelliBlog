
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IntelliBlog.API.Application.UseCases.Articles.List;

public readonly record struct ListArticlesQuery(
    int? Skip, 
    int? Take)
    : IQuery<Result<IEnumerable<ArticleDTO>>>;
