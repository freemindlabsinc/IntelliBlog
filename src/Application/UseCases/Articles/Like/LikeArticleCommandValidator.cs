namespace Blogging.Application.UseCases.Articles.AddLike;

public class LikeArticleCommandValidator : AbstractValidator<LikeArticleCommand>
{
    public LikeArticleCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
        RuleFor(x => x.LikedBy).NotEmpty();
    }
}
