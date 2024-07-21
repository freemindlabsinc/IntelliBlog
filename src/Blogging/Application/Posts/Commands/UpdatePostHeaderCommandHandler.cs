namespace Blogging.Application.Posts.Commands;

public class UpdatePostHeaderCommandHandler(
    IEntityRepository<Post> _repository)
    : IRequestHandler<UpdatePostHeaderCommand, Result>
{
    public async Task<Result> Handle(UpdatePostHeaderCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound();
        }

        Post.Value.UpdateTitle(command.NewTitle);
        Post.Value.UpdateDescription(command.NewDescription);

        await _repository.UpdateAsync(Post, cancellationToken);

        return Result.Success();
    }
}


