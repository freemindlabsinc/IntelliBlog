namespace Blogging.Application.UseCases.Articles.UpdateTags;

public class AddTagsCommandValidator : AbstractValidator<AddTagsCommand>
{
    public AddTagsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.NewTags).NotEmpty();
    }
}
