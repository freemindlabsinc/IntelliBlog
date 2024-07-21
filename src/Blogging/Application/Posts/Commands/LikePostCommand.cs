namespace Blogging.Application.Posts.Commands;
public record LikePostCommand(
    int PostId,
    string LikedBy)
    : ICommand<Result<int>>
{

    public class LikePostCommandValidator : AbstractValidator<LikePostCommand>
    {
        public LikePostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.LikedBy).NotEmpty();
        }
    }

}

