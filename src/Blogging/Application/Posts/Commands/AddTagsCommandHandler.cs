namespace Blogging.Application.Posts.Commands;

// Handler
internal class AddTagsCommandHandler(
    IEntityRepository<Post> _repository)
    : ICommandHandler<AddTagsCommand, Result<int>>
{
    public async Task<Result<int>> Handle(AddTagsCommand command, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (result == null)
        {
            return Result.NotFound();
        }

        result.Value.RemoveTags(command.NewTags);

        await _repository.UpdateAsync(result, cancellationToken);

        return Result.Success(result.Value.Tags.Count);
    }
}
