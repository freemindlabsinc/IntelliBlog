using Blogging.Domain.Aggregates.Articles;

namespace Application.UseCases.Articles.Publish;
public readonly record struct PublishArticleCommand(int ArticleId) : ICommand<Result>;


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

public class PublishArticleCommandValidator : AbstractValidator<PublishArticleCommand>
{
    public PublishArticleCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
    }
}
