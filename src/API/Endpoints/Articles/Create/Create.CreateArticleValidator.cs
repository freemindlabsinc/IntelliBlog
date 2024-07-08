using FastEndpoints;
using FluentValidation;

namespace API.Endpoints.Articles.Create;

public class CreateArticleValidator : Validator<CreateArticleRequest>
{
    public CreateArticleValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}
