namespace Blogging.Application.Posts.Commands;

internal class UnpublishPostCommandHandler(
    IEntityRepository<Post> _repository
    ) : ICommandHandler<UnpublishPostCommand, Result>
{
    public async Task<Result> Handle(UnpublishPostCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound("Post not found");
        }

        Post.Unpublish();

        return Result.Success();
    }
}
