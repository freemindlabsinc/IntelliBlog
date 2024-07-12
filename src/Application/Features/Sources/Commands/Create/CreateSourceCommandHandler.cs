using Blogging.Domain.Aggregates.Sources;

namespace Application.Features.Sources.Commands.Create;

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
