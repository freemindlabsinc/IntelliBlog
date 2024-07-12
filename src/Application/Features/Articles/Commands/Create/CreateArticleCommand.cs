using Blogging.Domain.Aggregates.Articles;

namespace Application.Features.Articles.Commands.Create;
public readonly record struct CreateArticleCommand(
    int BlogId,
    string Title,
    string? Description = default,
    string? Text = default,
    string[]? Tags = default) : ICommand<Result<int>>;

internal class CreateArticleCommandHandler(IRepository<Article> _repository) :
    ICommandHandler<CreateArticleCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
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
