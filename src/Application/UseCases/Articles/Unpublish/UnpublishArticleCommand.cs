using Blogging.Domain.Aggregates.Articles;

namespace Application.UseCases.Articles.Unpublish;

public readonly record struct UnpublishArticleCommand(int ArticleId) : ICommand<Result>;

internal class UnpublishArticleCommandHandler(
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

internal class UnpublishArticleCommandValidator : AbstractValidator<UnpublishArticleCommand>
{
    public UnpublishArticleCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
    }
}
