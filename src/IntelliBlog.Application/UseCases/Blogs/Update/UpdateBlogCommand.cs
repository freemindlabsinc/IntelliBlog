namespace IntelliBlog.Application.UseCases.Blogs.Update;

public readonly record struct UpdateBlogCommand(BlogId Id, string Name, string? Description, string? Notes)
    : ICommand<Result>;
