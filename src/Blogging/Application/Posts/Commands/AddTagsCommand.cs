namespace Blogging.Application.Posts.Commands;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="NewTags"></param>
public record AddTagsCommand(
    int Id,
    string[] NewTags)
    : ICommand<Result<int>>
{
    // Validator
    internal class AddTagsCommandValidator : AbstractValidator<AddTagsCommand>
    {
        public AddTagsCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.NewTags).NotEmpty();
        }
    }
}
