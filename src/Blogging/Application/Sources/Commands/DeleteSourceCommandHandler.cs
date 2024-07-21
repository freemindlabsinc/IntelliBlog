namespace Blogging.Application.Sources.Commands;

internal class DeleteSourceCommandHandler(
    IEntityRepository<Source> _repository
    ) : ICommandHandler<DeleteSourceCommand, Result>
{
    public async Task<Result> Handle(DeleteSourceCommand request, CancellationToken cancellationToken)
    {
        var source = await _repository.GetByIdAsync(request.SourceId, cancellationToken);

        if (source is null)
        {
            return Result.NotFound("Source not found");
        }

        await _repository.DeleteAsync(source.Value.Id, cancellationToken);

        return Result.Success();
    }
}
