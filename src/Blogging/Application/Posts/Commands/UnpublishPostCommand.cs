namespace Blogging.Application.Posts.Commands;

public record UnpublishPostCommand(int PostId) : ICommand<Result>
{
    internal class UnpublishPostCommandValidator : AbstractValidator<UnpublishPostCommand>
    {
        public UnpublishPostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
        }
    }
}
