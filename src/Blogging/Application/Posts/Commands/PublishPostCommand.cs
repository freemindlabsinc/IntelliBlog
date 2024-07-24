namespace Blogging.Application.Posts.Commands;
public record PublishPostCommand(int PostId) : ICommand<Result>
{
    public class PublishPostCommandValidator : AbstractValidator<PublishPostCommand>
    {
        public PublishPostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
        }
    }

}

