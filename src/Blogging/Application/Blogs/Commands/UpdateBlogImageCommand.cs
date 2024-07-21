namespace Blogging.Application.Blogs.Commands;

public record UpdateBlogImageCommand(int Id, string Image, string SmallImage)
    : ICommand<Result>
{
    internal class UpdateBlogImageValidator : AbstractValidator<UpdateBlogImageCommand>
    {
        public UpdateBlogImageValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            // TODO: Validate url
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.SmallImage).NotEmpty();
        }
    }
}
