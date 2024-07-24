namespace Blogging.Application.Posts.Commands;

public record UpdatePostHeaderCommand(
    int PostId,
    string NewTitle,
    string NewDescription
    ) : ICommand<Result>
{

    public class UpdatePostHeaderCommandValidator : AbstractValidator<UpdatePostHeaderCommand>
    {
        public UpdatePostHeaderCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.NewTitle).NotEmpty();
            RuleFor(x => x.NewDescription).NotEmpty();
        }
    }
}


