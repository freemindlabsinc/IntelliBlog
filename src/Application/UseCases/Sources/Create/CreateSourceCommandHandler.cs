using Blogging.Domain.Aggregates.Sources;
using Blogging.Domain.Specifications;

namespace Blogging.Application.UseCases.Sources.Create;

public class CreateSourceCommandHandler(
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
