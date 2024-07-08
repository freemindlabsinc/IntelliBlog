namespace Blogging.Application.UseCases.Blogs.UpdateImages;

public class UpdateBlogImagesValidator : AbstractValidator<UpdateBlogImagesCommand>
{
    public UpdateBlogImagesValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        // TODO: Iffy. We need to make a value object
        RuleFor(x => x.Image).NotEmpty();
        RuleFor(x => x.SmallImage).NotEmpty();
    }
}
