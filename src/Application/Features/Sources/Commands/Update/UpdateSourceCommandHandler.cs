using Blogging.Domain.Aggregates.Sources;

namespace Application.Features.Sources.Commands.Update;

internal class UpdateSourceCommandHandler(
    IRepository<Source> _repository
    ) : ICommandHandler<UpdateSourceCommand, Result>
{
    public async Task<Result> Handle(UpdateSourceCommand request, CancellationToken cancellationToken)
    {
        var spec = new SourceByIdSpec(request.SourceId);
        var source = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if (source is null)
        {
            return Result.NotFound();
        }

        source.UpdateName(request.Name);
        source.UpdateURL(request.Url);
        source.UpdateDescription(request.Description);

        await _repository.UpdateAsync(source, cancellationToken);

        return Result.Success();
    }
}
