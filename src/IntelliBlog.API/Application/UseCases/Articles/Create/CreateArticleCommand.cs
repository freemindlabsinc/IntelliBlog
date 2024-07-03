using IntelliBlog.Domain.Blogs;

namespace IntelliBlog.API.Application.UseCases.Articles.Create;

public readonly record struct CreateArticleCommand(
    int BlogId,
    string Title,
    string? Description,
    string? Text,
    string[]? Tags) 
    : ICommand<Result<int>>;
