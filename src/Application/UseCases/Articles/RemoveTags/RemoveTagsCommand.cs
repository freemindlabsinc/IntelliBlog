using Blogging.Domain.Aggregates.Articles;

namespace Application.UseCases.Articles.RemoveTags;
public readonly record struct RemoveTagsCommand(
    ArticleId Id,
    string[] TagsToRemove
    ) : ICommand<Result<int>>;

public class RemoveTagsCommandHandler(IRepository<Article> _repository)
    : ICommandHandler<RemoveTagsCommand, Result<int>>
{
    public async Task<Result<int>> Handle(RemoveTagsCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.Id);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
        {
            return Result.NotFound();
        }

        var tagsToRemove = command.TagsToRemove;
        var removedTags = article.RemoveTags(tagsToRemove);

        await _repository.UpdateAsync(article, cancellationToken);

        return Result.Success(article.Tags.Count);
    }
}

public class RemoveTagsCommandValidator : AbstractValidator<RemoveTagsCommand>
{
    public RemoveTagsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.TagsToRemove).NotEmpty();
    }
}
