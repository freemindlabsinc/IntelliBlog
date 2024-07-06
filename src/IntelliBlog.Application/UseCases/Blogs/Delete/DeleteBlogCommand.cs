namespace IntelliBlog.Application.UseCases.Blogs.Delete;

public readonly record struct DeleteBlogCommand(BlogId Id) : ICommand<Result>;
