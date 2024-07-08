using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.Unpublish;

public class UnpublishArticleCommandHandler(
    IRepository<Article> _repository
    ) : ICommandHandler<UnpublishArticleCommand, Result>
{
    public async Task<Result> Handle(UnpublishArticleCommand command, CancellationToken cancellationToken)
    {
        var article = await _repository.GetByIdAsync(command.ArticleId, cancellationToken);
        if (article == null)
        {
            return Result.NotFound("Article not found");
        }

        article.Unpublish();

        return Result.Success();
    }
}
