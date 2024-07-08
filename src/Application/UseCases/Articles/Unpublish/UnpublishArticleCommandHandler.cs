using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.Unpublish;

public class UnpublishArticleCommandHandler(
    IRepository<Article> _repository
    ) : ICommandHandler<UnpublishArticleCommand, Result>
{
    public async Task<Result> Handle(UnpublishArticleCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.ArticleId);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
        {
            return Result.NotFound("Article not found");
        }

        article.Unpublish();

        return Result.Success();
    }
}

