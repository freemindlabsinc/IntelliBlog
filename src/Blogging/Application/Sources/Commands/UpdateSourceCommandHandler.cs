namespace Blogging.Application.Sources.Commands;

internal class UpdateSourceCommandHandler(
    IEntityRepository<Source> _repository
    ) : ICommandHandler<UpdateSourceCommand, Result>
{
    public async Task<Result> Handle(UpdateSourceCommand request, CancellationToken cancellationToken)
    {
        var source = await _repository.GetByIdAsync(request.SourceId, cancellationToken);

        if (source is null)
        {
            return Result.NotFound();
        }

        source.Value.UpdateName(request.Name);
        source.Value.UpdateURL(request.Url);
        source.Value.UpdateDescription(request.Description);

        await _repository.UpdateAsync(source, cancellationToken);

        return Result.Success();
    }
}
