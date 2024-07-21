namespace Blogging.Application.Posts.Commands;

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

        Post.RemoveTags(command.NewTags);

        await _repository.UpdateAsync(Post, cancellationToken);

        return Result.Success(Post.Tags.Count);
    }
}
