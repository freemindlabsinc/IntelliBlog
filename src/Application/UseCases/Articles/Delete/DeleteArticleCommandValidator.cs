namespace Blogging.Application.UseCases.Articles.Delete;

public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
{
    public DeleteArticleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

