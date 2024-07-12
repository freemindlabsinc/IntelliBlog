namespace Application.Features.Sources.Commands.Create;
public readonly record struct CreateSourceCommand(
    int BlogId,
    string Name,
    string? Url = default,
    string? Description = default,
    string[]? Tags = default) : ICommand<Result<int>>
{
    internal class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
    {
        public CreateSourceCommandValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
