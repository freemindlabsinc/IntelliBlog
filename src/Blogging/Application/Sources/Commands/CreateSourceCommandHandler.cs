namespace Blogging.Application.Sources.Commands;

internal class CreateSourceCommandHandler(
    IEntityRepository<Source> _repository
    ) : ICommandHandler<CreateSourceCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateSourceCommand command, CancellationToken cancellationToken)
    {
        var source = new Source(command.BlogId, command.Name, command.Url, command.Description);

        await _repository.CreateAsync(source, cancellationToken);

        return Result<int>.Success(source.Id);
    }
}
