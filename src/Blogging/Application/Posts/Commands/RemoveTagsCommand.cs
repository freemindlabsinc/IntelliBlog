namespace Blogging.Application.Posts.Commands;
public record RemoveTagsCommand(
    int Id,
    string[] TagsToRemove
    ) : ICommand<Result<int>>;

public class RemoveTagsCommandHandler(IRepository<Post> _repository)
    : ICommandHandler<RemoveTagsCommand, Result<int>>
{
    public async Task<Result<int>> Handle(RemoveTagsCommand command, CancellationToken cancellationToken)
    {
        var post = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (post == null)
        {
            return Result.NotFound();
        }
        
        post.RemoveTags(command.TagsToRemove);

        await _repository.UpdateAsync(post, cancellationToken);

        return Result.Success();
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
