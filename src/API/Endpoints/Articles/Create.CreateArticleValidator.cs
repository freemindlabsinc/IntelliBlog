using FastEndpoints;
using FluentValidation;

namespace Blogging.API.Endpoints.Articles;

public class CreateArticleValidator : Validator<CreateArticleRequest>
{
    public CreateArticleValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}
