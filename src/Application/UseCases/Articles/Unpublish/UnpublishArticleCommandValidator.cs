namespace Blogging.Application.UseCases.Articles.Unpublish;

public class UnpublishArticleCommandValidator : AbstractValidator<UnpublishArticleCommand>
{
    public UnpublishArticleCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
    }
}
