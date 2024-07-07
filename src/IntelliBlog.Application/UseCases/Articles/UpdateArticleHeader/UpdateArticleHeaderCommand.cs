namespace IntelliBlog.Application.UseCases.Articles.Update;

public readonly record struct UpdateArticleHeaderCommand(
    BlogId Id,
    string NewTitle,
    string NewDescription
    ) : ICommand<Result<BlogId>>;
