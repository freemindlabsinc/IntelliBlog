namespace Blogging.Application.Sources.Commands;

public record DeleteSourceCommand(int SourceId) : ICommand<Result>
{
    internal class DeleteSourceCommandValidator : AbstractValidator<DeleteSourceCommand>
    {
        public DeleteSourceCommandValidator()
        {
            RuleFor(x => x.SourceId).NotEmpty();
        }
    }
}
