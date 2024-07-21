namespace Blogging.Application.Posts.Commands;

public class LikePostCommandHandler(
    IRepository<Post> _repository)
    : ICommandHandler<LikePostCommand, Result<int>>
{
    public async Task<Result<int>> Handle(LikePostCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (Post == null)
        {
            return Result<int>.NotFound("Post not found");
        }

        Post.Like(command.LikedBy);

        await _repository.UpdateAsync(Post, cancellationToken);

        return Result<int>.Success(Post.Likes.Count);
    }
}

