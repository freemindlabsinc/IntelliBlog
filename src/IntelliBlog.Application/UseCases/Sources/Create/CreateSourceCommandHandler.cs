using Blogging.Domain.Aggregates.Sources;

namespace Blogging.Application.UseCases.Sources.Create;

public class CreateSourceCommandHandler(
    IRepository<Source> _repository
    ) : ICommandHandler<CreateSourceCommand, Result<SourceId>>
{
    public async Task<Result<SourceId>> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
    {
        var source = Source.CreateNew(request.BlogId, request.Name, request.Url, request.Description);

        await _repository.AddAsync(source, cancellationToken);

        return Result<SourceId>.Success(source.Id);
    }
}
