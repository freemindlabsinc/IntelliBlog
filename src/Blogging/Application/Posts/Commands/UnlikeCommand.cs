namespace Blogging.Application.Posts.Commands;

public record UnlikeCommand(
    int PostId,
    string likedBy)
    : ICommand<Result<int>>
{

    public class UnlikeCommandValidator : AbstractValidator<UnlikeCommand>
    {
        public UnlikeCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.likedBy).NotEmpty();
        }
    }

}

