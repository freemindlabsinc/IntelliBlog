using FastEndpoints;
using FluentValidation;

namespace Blogging.API.Endpoints.Articles;

public class CreateArticleValidator : Validator<CreateArticleRequest>
{
    public CreateArticleValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        //RuleFor(x => x.Description).NotEmpty();
        //RuleFor(x => x.Content).NotEmpty();
        //RuleFor(x => x.Tags).NotEmpty();
    }
}
