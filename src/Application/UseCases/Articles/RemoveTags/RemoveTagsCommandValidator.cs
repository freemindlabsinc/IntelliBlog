namespace Blogging.Application.UseCases.Articles.RemoveTags;

public class RemoveTagsCommandValidator : AbstractValidator<RemoveTagsCommand>
{
    public RemoveTagsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.TagsToRemove).NotEmpty();
    }
}
