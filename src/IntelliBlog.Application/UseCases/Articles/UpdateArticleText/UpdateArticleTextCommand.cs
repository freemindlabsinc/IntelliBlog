namespace Blogging.Application.UseCases.Articles.Update;

public readonly record struct UpdateArticleTextCommand(
    BlogId Id,
    string newText
    ) : ICommand<Result<BlogId>>;
