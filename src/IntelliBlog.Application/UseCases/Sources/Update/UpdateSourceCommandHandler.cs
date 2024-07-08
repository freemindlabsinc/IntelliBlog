using Blogging.Domain.Aggregates.Sources;

namespace Blogging.Application.UseCases.Sources.Update;

public class UpdateSourceCommandHandler(
    IRepository<Source> _repository
    ) : ICommandHandler<UpdateSourceCommand, Result>
{
    public async Task<Result> Handle(UpdateSourceCommand request, CancellationToken cancellationToken)
    {
        var source = await _repository.GetByIdAsync(request.SourceId, cancellationToken);

        if (source is null)
        {
            return Result.NotFound("Source not found");
        }

        source.UpdateName(request.Name);
        source.UpdateURL(request.Url);
        source.UpdateDescription(request.Description);

        await _repository.UpdateAsync(source, cancellationToken);

        return Result.Success();
    }
}
