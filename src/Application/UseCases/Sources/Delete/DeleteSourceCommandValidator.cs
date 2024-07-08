namespace Blogging.Application.UseCases.Sources.Delete;

public class DeleteSourceCommandValidator : AbstractValidator<DeleteSourceCommand>
{
    public DeleteSourceCommandValidator()
    {
        RuleFor(x => x.SourceId).NotEmpty();
    }
}
