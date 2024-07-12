using Blogging.Domain.Aggregates.Sources;

namespace Application.Features.Sources.Commands.Delete;

public readonly record struct DeleteSourceCommand(int SourceId) : ICommand<Result>;

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

internal class DeleteSourceCommandValidator : AbstractValidator<DeleteSourceCommand>
{
    public DeleteSourceCommandValidator()
    {
        RuleFor(x => x.SourceId).NotEmpty();
    }
}
