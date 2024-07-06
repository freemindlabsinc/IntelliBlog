using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Application.UseCases.Blogs.ChangeStatus;

public readonly record struct ChangeBlogStatusCommand(BlogId Id, BlogStatus NewStatus)
    : ICommand<Result>;
