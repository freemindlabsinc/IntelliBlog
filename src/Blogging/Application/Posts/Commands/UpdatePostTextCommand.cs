namespace Blogging.Application.Posts.Commands;

public record UpdatePostTextCommand(
    int PostId,
    string Description,
    string Text
    ) : ICommand<Result>;


internal class UpdatePostTextCommandHandler(
    IRepository<Post> _repository)
    : ICommandHandler<UpdatePostTextCommand, Result>
{
    public async Task<Result> Handle(UpdatePostTextCommand command, CancellationToken cancellationToken)
    {
        var post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (post == null)
            return Result.NotFound();

        post.UpdateText(command.Description);
        post.UpdateText(command.Text);
        await _repository.UpdateAsync(post, cancellationToken);

        return Result.Success();
    }
}

internal class UpdatePostTextCommandValidator : AbstractValidator<UpdatePostTextCommand>
{
    public UpdatePostTextCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Text).NotEmpty();
    }
}
