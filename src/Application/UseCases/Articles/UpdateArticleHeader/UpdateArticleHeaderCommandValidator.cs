namespace Blogging.Application.UseCases.Articles.Update;

public class UpdateArticleHeaderCommandValidator : AbstractValidator<UpdateArticleHeaderCommand>
{
    public UpdateArticleHeaderCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
        RuleFor(x => x.NewTitle).NotEmpty();
        RuleFor(x => x.NewDescription).NotEmpty();
    }
}
