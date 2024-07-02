using FluentValidation;

namespace IntelliBlog.API.Endpoints.Articles;

public class CreateArticleValidator : AbstractValidator<CreateArticleRequest>
{
    public CreateArticleValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        //RuleFor(x => x.Description).NotEmpty();
        //RuleFor(x => x.Content).NotEmpty();
        //RuleFor(x => x.Tags).NotEmpty();
    }
}
