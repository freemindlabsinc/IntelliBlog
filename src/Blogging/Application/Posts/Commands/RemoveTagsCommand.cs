namespace Blogging.Application.Posts.Commands;
public record RemoveTagsCommand(
    int Id,
    string[] TagsToRemove
    ) : ICommand<Result<int>>
{

    public class RemoveTagsCommandValidator : AbstractValidator<RemoveTagsCommand>
    {
        public RemoveTagsCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.TagsToRemove).NotEmpty();
        }
    }

}
