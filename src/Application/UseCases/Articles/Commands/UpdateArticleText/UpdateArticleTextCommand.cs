using Blogging.Domain.Aggregates.Articles;

namespace Application.UseCases.Articles.Commands.UpdateArticleText;

public readonly record struct UpdateArticleTextCommand(
    int ArticleId,
    string Description,
    string Text
    ) : ICommand<Result>;


internal class UpdateArticleTextCommandHandler(
    IRepository<Article> _repository)
    : ICommandHandler<UpdateArticleTextCommand, Result>
{
    public async Task<Result> Handle(UpdateArticleTextCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.ArticleId);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
            return Result.NotFound();

        article.UpdateText(command.Description);
        article.UpdateText(command.Text);
        await _repository.UpdateAsync(article, cancellationToken);

        return Result.Success();
    }
}

internal class UpdateArticleTextCommandValidator : AbstractValidator<UpdateArticleTextCommand>
{
    public UpdateArticleTextCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Text).NotEmpty();
    }
}
