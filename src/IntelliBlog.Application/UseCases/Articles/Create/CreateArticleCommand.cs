using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Application.UseCases.Articles.Create;
public record CreateArticleCommand(
    string Title,
    string Description,
    string Content,
    string[] Tags) : ICommand<Result<ArticleId>>;
