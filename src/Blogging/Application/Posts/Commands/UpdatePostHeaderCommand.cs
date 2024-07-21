namespace Blogging.Application.Posts.Commands;

public record UpdatePostHeaderCommand(
    int PostId,
    string NewTitle,
    string NewDescription
    ) : ICommand<Result>;


public class UpdatePostHeaderCommandHandler(
    IRepository<Post> _repository)
    : IRequestHandler<UpdatePostHeaderCommand, Result>
{
    public async Task<Result> Handle(UpdatePostHeaderCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.PostId, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound();
        }

        Post.UpdateTitle(command.NewTitle);
        Post.UpdateDescription(command.NewDescription);

        await _repository.UpdateAsync(Post, cancellationToken);

        return Result.Success();
    }
}

public class UpdatePostHeaderCommandValidator : AbstractValidator<UpdatePostHeaderCommand>
{
    public UpdatePostHeaderCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.NewTitle).NotEmpty();
        RuleFor(x => x.NewDescription).NotEmpty();
    }
}

