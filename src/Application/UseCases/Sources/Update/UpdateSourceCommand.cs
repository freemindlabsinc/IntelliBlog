namespace Blogging.Application.UseCases.Sources.Update;

public readonly record struct UpdateSourceCommand(
    SourceId SourceId,
    string Name,
    string? Url = default,
    string? Description = default) : ICommand<Result>;
