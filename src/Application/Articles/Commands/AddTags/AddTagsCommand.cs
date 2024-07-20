using Blogging.Domain.Aggregates.Articles;

namespace Application.Articles.Commands.AddTags;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="NewTags"></param>
public readonly record struct AddTagsCommand(
    int Id,
    string[] NewTags)
    : ICommand<Result<int>>;


// Handler
internal class AddTagsCommandHandler(IRepository<Article> _repository)
    : ICommandHandler<AddTagsCommand, Result<int>>
{
    public async Task<Result<int>> Handle(AddTagsCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.Id);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
        {
            return Result.NotFound();
        }

        var removedTags = article.RemoveTags(command.NewTags);

        await _repository.UpdateAsync(article, cancellationToken);

        return Result.Success(article.Tags.Count);
    }
}

// Validator
internal class AddTagsCommandValidator : AbstractValidator<AddTagsCommand>
{
    public AddTagsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.NewTags).NotEmpty();
    }
}
