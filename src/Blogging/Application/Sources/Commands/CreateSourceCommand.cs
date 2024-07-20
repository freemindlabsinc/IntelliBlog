namespace Blogging.Application.Sources.Commands;
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
