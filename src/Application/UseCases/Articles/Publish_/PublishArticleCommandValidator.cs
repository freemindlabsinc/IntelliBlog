namespace Blogging.Application.UseCases.Articles.Publish;

public class PublishArticleCommandValidator : AbstractValidator<PublishArticleCommand>
{
    public PublishArticleCommandValidator()
    {
        RuleFor(x => x.ArticleId).NotEmpty();
    }
} 
