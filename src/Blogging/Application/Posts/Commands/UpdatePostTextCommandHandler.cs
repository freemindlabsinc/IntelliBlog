namespace Blogging.Application.Posts.Commands;

internal class UpdatePostTextCommandHandler(
    IEntityRepository<Post> _repository)
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
