namespace IntelliBlog.API.Application.UseCases.Sources.Create;

public readonly record struct CreateSourceCommand(
    int BlogId,
    string Name,
    string? Url,
    string? Description,
    string[]? Tags) : ICommand<Result<int>>;
