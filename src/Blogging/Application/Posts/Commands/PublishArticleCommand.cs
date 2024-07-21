namespace Blogging.Application.Posts.Commands;
public record PublishPostCommand(int PostId) : ICommand<Result>;


public class PublishPostCommandHandler(
    IRepository<Post> _repository
    ) : ICommandHandler<PublishPostCommand, Result>
{
    public async Task<Result> Handle(PublishPostCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound("Post not found");
        }

        Post.Publish();

        return Result.Success();
    }
}

public class PublishPostCommandValidator : AbstractValidator<PublishPostCommand>
{
    public PublishPostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}
