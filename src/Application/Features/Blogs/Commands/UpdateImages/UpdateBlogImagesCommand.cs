namespace Application.Features.Blogs.Commands.UpdateImages;

public readonly record struct UpdateBlogImagesCommand(int Id, string Image, string SmallImage)
    : ICommand<Result>
{
    internal class UpdateBlogImagesValidator : AbstractValidator<UpdateBlogImagesCommand>
    {
        public UpdateBlogImagesValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            // TODO: Iffy. We need to make a value object
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.SmallImage).NotEmpty();
        }
    }
}
