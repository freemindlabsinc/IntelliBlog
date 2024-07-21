namespace Blogging.Application.Posts.Commands;

public class PublishPostCommandHandler(
    IEntityRepository<Post> _repository
    ) : ICommandHandler<PublishPostCommand, Result>
{
    public async Task<Result> Handle(PublishPostCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound("Post not found");
        }

        Post.Value.Publish();

        return Result.Success();
    }
}

