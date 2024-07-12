using Blogging.Domain.Aggregates.Sources;

namespace Application.Features.Sources.Commands.Create;
public readonly record struct CreateSourceCommand(
    int BlogId,
    string Name,
    string? Url = default,
    string? Description = default,
    string[]? Tags = default) : ICommand<Result<int>>;

internal class CreateSourceCommandHandler(
    IRepository<Source> _repository
    ) : ICommandHandler<CreateSourceCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateSourceCommand command, CancellationToken cancellationToken)
    {
        var source = Source.CreateNew(command.BlogId, command.Name, command.Url, command.Description);

        await _repository.AddAsync(source, cancellationToken);

        return Result<int>.Success(source.Id);
    }
}

internal class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
{
    public CreateSourceCommandValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}
