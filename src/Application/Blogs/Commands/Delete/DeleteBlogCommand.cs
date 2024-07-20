namespace Application.Blogs.Commands.Delete;

public readonly record struct DeleteBlogCommand(int Id) : ICommand<Result>
{
    internal class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}


