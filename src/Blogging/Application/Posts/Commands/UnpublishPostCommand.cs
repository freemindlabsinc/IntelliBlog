namespace Blogging.Application.Posts.Commands;

public record UnpublishPostCommand(int PostId) : ICommand<Result>;

internal class UnpublishPostCommandHandler(
    IRepository<Post> _repository
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

internal class UnpublishPostCommandValidator : AbstractValidator<UnpublishPostCommand>
{
    public UnpublishPostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}
