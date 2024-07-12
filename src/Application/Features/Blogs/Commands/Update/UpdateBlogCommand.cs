namespace Application.Features.Blogs.Commands.Update;

public readonly record struct UpdateBlogCommand(int Id, string Name, string? Description, string? Notes)
    : ICommand<Result>
{
    internal class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
        {
            // TODO review lengths
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);
            RuleFor(x => x.Notes).MaximumLength(2000);
        }
    }
}
