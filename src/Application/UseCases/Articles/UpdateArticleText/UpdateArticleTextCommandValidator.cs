namespace Blogging.Application.UseCases.Articles.Update;

public class UpdateArticleTextCommandValidator : AbstractValidator<UpdateArticleTextCommand>
{
    public UpdateArticleTextCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Text).NotEmpty();
    }
}
