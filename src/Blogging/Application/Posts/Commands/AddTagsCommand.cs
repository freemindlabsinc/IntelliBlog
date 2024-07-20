namespace Blogging.Application.Posts.Commands;

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
internal class AddTagsCommandHandler(IRepository<Post> _repository)
    : ICommandHandler<AddTagsCommand, Result<int>>
{
    public async Task<Result<int>> Handle(AddTagsCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound();
        }

        var removedTags = Post.RemoveTags(command.NewTags);

        await _repository.UpdateAsync(Post, cancellationToken);

        return Result.Success(Post.Tags.Count);
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
