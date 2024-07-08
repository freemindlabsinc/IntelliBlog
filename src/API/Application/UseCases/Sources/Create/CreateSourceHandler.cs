using Blogging.Domain.Aggregates.Sources;

namespace Blogging.API.Application.UseCases.Sources.Create;

public class CreateSourceHandler(IRepository<Source> _repository) 
    : ICommandHandler<CreateSourceCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
    {
        var source = Source.CreateNew(request.BlogId, request.Name, request.Url, request.Description);

        var createdItem = await _repository.AddAsync(source, cancellationToken);

        return createdItem.Id.Value;
    }
}
