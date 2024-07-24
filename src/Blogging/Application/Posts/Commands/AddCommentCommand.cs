namespace Blogging.Application.Posts.Commands;

public record AddCommentCommand
{
    internal class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            //RuleFor(x => x.).NotEmpty();            
        }
    }
}
