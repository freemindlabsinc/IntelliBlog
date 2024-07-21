namespace Blogging.Application.Blogs.Commands;

public record UpdateBlogCommand(int Id, string Name, string? Description = default, string? Notes = default)
    : ICommand<Result>
{
    internal class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
        {            
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            
            When(x => x.Description != null, () =>
            {
                RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);                
            });

            When(x => x.Notes != null, () =>
            {
                RuleFor(x => x.Notes).NotEmpty();

            });            
        }
    }
}
