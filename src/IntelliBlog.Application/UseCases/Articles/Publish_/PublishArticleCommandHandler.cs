using IntelliBlog.Domain.Aggregates.Articles;

namespace IntelliBlog.Application.UseCases.Articles.Publish;

public class PublishArticleCommandHandler(
    IRepository<Article> _repository
    ) : ICommandHandler<PublishArticleCommand, Result>
{
    public async Task<Result> Handle(PublishArticleCommand command, CancellationToken cancellationToken)
    {
        var article = await _repository.GetByIdAsync(command.ArticleId, cancellationToken);
        if (article == null)
        {
            return Result.NotFound("Article not found");
        }

        article.Publish();

        return Result.Success();
    }
}
