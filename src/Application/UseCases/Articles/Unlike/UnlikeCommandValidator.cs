namespace Blogging.Application.UseCases.Articles.RemoveLike;

public class UnlikeCommandValidator : AbstractValidator<UnlikeCommand>
{
    public UnlikeCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
        RuleFor(x => x.likedBy).NotEmpty();
    }
}
