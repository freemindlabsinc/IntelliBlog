namespace Application.Features.Blogs.Commands.Create;

/// <summary>
/// Creates a new blog for the user.
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
public readonly record struct CreateBlogCommand(
    string Name, 
    string? Description = default)

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
