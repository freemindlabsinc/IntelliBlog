using Blogging.Domain.Aggregates.Articles;

namespace Application.Features.Articles.Commands.Delete;

public readonly record struct DeleteArticleCommand(int Id) : ICommand<Result>;

public class DeleteArticleCommandHandler(IRepository<Article> _repository) : ICommandHandler<DeleteArticleCommand, Result>
{
    public async Task<Result> Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
    {
        var article = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (article == null)
        {
            return Result.NotFound("Article not found");
        }

        article.MarkDeleted();
        await _repository.DeleteAsync(article);

        return Result.Success();
    }
}

public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
{
    public DeleteArticleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

