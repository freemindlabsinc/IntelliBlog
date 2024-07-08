namespace Blogging.Application.UseCases.Sources.Create;

public class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
{
    public CreateSourceCommandValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();        
    }
}
