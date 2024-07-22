namespace Blogging.Application.Posts.Commands;

public class RemoveTagsCommandHandler(IEntityRepository<Post> _repository)
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
