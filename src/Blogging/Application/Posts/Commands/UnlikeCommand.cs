namespace Blogging.Application.Posts.Commands;

public record UnlikeCommand(
    int PostId,
    string likedBy)
    : ICommand<Result<int>>;

public class UnlikeCommandHandler(
    IRepository<Post> _repository) : ICommandHandler<UnlikeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UnlikeCommand command, CancellationToken cancellationToken)
    {
        var post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (post == null)
        {
            return Result.NotFound();
        }

        post.Unlike(command.likedBy);

        await _repository.UpdateAsync(post, cancellationToken);

        return Result<int>.Success(post.Likes.Count);
    }
}


public class UnlikeCommandValidator : AbstractValidator<UnlikeCommand>
{
    public UnlikeCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.likedBy).NotEmpty();
    }
}
