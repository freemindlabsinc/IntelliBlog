using Blogging.Domain.Aggregates.Articles;

namespace Application.Features.Articles.Commands.UpdateArticleHeader;

public readonly record struct UpdateArticleHeaderCommand(
    int ArticleId,
    string NewTitle,
    string NewDescription
    ) : ICommand<Result>;


public class UpdateArticleHeaderCommandHandler(
    IRepository<Article> _repository)
    : IRequestHandler<UpdateArticleHeaderCommand, Result>
{
    public async Task<Result> Handle(UpdateArticleHeaderCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.ArticleId);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
        {
            return Result.NotFound();
        }

        article.UpdateTitle(command.NewTitle);
        article.UpdateDescription(command.NewDescription);

        await _repository.UpdateAsync(article, cancellationToken);

        return Result.Success();
    }
}

public class UpdateArticleHeaderCommandValidator : AbstractValidator<UpdateArticleHeaderCommand>
{
    public UpdateArticleHeaderCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
        RuleFor(x => x.NewTitle).NotEmpty();
        RuleFor(x => x.NewDescription).NotEmpty();
    }
}

