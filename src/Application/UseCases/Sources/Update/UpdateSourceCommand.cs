using Blogging.Domain.Aggregates.Sources;

namespace Application.UseCases.Sources.Update;

public readonly record struct UpdateSourceCommand(
    int SourceId,
    string Name,
    string? Url = default,
    string? Description = default) : ICommand<Result>;

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

internal class UpdateSourceCommandValidator : AbstractValidator<UpdateSourceCommand>
{
    public UpdateSourceCommandValidator()
    {
        RuleFor(x => x.SourceId).NotEmpty();
        // TODO review length
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
