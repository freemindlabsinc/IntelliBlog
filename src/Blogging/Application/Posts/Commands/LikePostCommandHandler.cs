namespace Blogging.Application.Posts.Commands;

public class LikePostCommandHandler(
    IEntityRepository<Post> _repository)
    : ICommandHandler<LikePostCommand, Result<int>>
{
    public async Task<Result<int>> Handle(LikePostCommand command, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (result == null)
        {
            return Result<int>.NotFound("Post not found");
        }

        result.Like(command.LikedBy);

        // HACK Interesting how I can pass either the result or the result.Value to the UpdateAsync method
        // Should I be clearer/consistent?
        await _repository.UpdateAsync(result, cancellationToken);

        return Result<int>.Success(result.Likes.Count);
    }
}

