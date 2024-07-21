namespace Blogging.Application.Blogs.Commands;

/// <summary>
/// Creates a new blog for the user.
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
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
