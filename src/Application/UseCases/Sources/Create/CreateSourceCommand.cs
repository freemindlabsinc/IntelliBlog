namespace Blogging.Application.UseCases.Sources.Create;
public readonly record struct CreateSourceCommand(
    BlogId BlogId,
    string Name,
    string? Url = default,
    string? Description = default,
    string[]? Tags = default) : ICommand<Result<SourceId>>;
