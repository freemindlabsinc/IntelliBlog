namespace IntelliBlog.API.Application.UseCases.Sources.Create;

public readonly record struct CreateSourceCommand(
    string Name,
    string? Url,
    string? Description,
    string[]? Tags) : ICommand<Result<int>>;
