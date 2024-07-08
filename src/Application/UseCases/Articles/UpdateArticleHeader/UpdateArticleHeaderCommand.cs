using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Blogging.Application.UseCases.Articles.Update;

public readonly record struct UpdateArticleHeaderCommand(
    ArticleId ArticleId,
    string NewTitle,
    string NewDescription    
    ) : ICommand<Result>;
