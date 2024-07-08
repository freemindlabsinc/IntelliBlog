namespace Blogging.Application.UseCases.Sources.Update;

public class UpdateSourceCommandValidator : AbstractValidator<UpdateSourceCommand>
{
    public UpdateSourceCommandValidator()
    {
        RuleFor(x => x.SourceId).NotEmpty();
        // TODO review length
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);        
    }
}
