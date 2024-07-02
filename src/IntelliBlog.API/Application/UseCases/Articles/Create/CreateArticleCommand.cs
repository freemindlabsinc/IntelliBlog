namespace IntelliBlog.API.Application.UseCases.Articles.Create;

public readonly record struct CreateArticleCommand(
    string Title,
    string Description,
    string Text,
    string[] Tags) : ICommand<Result<int>>;
