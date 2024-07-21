namespace Blogging.Application.Posts.Commands;

internal class CreatePostCommandHandler(
    IEntityRepository<Post> _repository) :
    ICommandHandler<CreatePostCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var Post = new Post(command.BlogId, command.Title, command.Description);

        Post.UpdateText(command.Text);

        if (command.Tags != null)
        {
            Post.AddTags(command.Tags);
        }

        await _repository.CreateAsync(Post, cancellationToken);

        return Result.Success(Post.Id);
    }
}

