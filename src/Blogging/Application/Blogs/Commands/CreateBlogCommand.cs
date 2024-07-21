namespace Blogging.Application.Blogs.Commands;

public record CreateBlogCommand(
    string Name,
    string? Description = default,
    string? Image = default,
    string? Notes = default)

    : ICommand<Result<int>>
{
    #region Validation

    internal class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();
        }
    }

    #endregion
}
