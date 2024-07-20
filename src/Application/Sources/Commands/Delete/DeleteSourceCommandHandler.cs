﻿using Blogging.Domain.Aggregates.Sources;

namespace Application.Sources.Commands.Delete;

internal class DeleteSourceCommandHandler(
    IRepository<Source> _repository
    ) : ICommandHandler<DeleteSourceCommand, Result>
{
    public async Task<Result> Handle(DeleteSourceCommand request, CancellationToken cancellationToken)
    {
        var spec = new SourceByIdSpec(request.SourceId);
        var source = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if (source is null)
        {
            return Result.NotFound("Source not found");
        }

        await _repository.DeleteAsync(source, cancellationToken);

        return Result.Success();
    }
}