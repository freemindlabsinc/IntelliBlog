using Blogging.Domain.Aggregates.Articles;

namespace Application.UseCases.Articles.Create;
public readonly record struct CreateArticleCommand(
    BlogId BlogId,
    string Title,
    string? Description = default,
    string? Text = default,
    string[]? Tags = default) : ICommand<Result<ArticleId>>;

internal class CreateArticleCommandHandler(IRepository<Article> _repository) :
    ICommandHandler<CreateArticleCommand, Result<ArticleId>>
{
    public async Task<Result<ArticleId>> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
    {
        var article = Article.CreateNew(command.BlogId, command.Title, command.Description);

        article.UpdateText(command.Text);

        if (command.Tags != null)
        {
            article.AddTags(command.Tags);
        }

        await _repository.AddAsync(article, cancellationToken);

        return Result.Success(article.Id);
    }
}

internal class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}
