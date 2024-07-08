namespace Blogging.Application.UseCases.Articles.Create;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}
