using Blogging.Domain.Aggregates.Sources;

namespace Application.UseCases.Sources.Create;
public readonly record struct CreateSourceCommand(
    BlogId BlogId,
    string Name,
    string? Url = default,
    string? Description = default,
    string[]? Tags = default) : ICommand<Result<SourceId>>;

internal class CreateSourceCommandHandler(
    IRepository<Source> _repository
    ) : ICommandHandler<CreateSourceCommand, Result<SourceId>>
{
    public async Task<Result<SourceId>> Handle(CreateSourceCommand command, CancellationToken cancellationToken)
    {
        var source = Source.CreateNew(command.BlogId, command.Name, command.Url, command.Description);

        await _repository.AddAsync(source, cancellationToken);

        return Result<SourceId>.Success(source.Id);
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
