namespace Blogging.Application.Posts.Commands;

public class UnlikeCommandHandler(
    IEntityRepository<Post> _repository) : ICommandHandler<UnlikeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UnlikeCommand command, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (response == null)
        {
            return Result.NotFound();
        }

        response.Value.Unlike(command.likedBy);

        await _repository.UpdateAsync(response, cancellationToken);

        return Result<int>.Success(response.Value.Likes.Count);
    }
}

