namespace Blogging.Application.Posts.Commands;

public record DeletePostCommand(int Id) : ICommand<Result>
{

    internal class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
