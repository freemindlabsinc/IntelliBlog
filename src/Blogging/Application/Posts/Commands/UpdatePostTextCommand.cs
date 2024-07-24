namespace Blogging.Application.Posts.Commands;

public record UpdatePostTextCommand(
    int PostId,
    string Description,
    string Text
    ) : ICommand<Result>
{

    internal class UpdatePostTextCommandValidator : AbstractValidator<UpdatePostTextCommand>
    {
        public UpdatePostTextCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Text).NotEmpty();
        }
    }

}
