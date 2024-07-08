using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.Update;

public class UpdateArticleHeaderCommandHandler(
    IRepository<Article> _repository) 
    : IRequestHandler<UpdateArticleHeaderCommand, Result>
{
    public async Task<Result> Handle(UpdateArticleHeaderCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.ArticleId);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
        {
            return Result.NotFound();
        }

        article.UpdateTitle(command.NewTitle);
        article.UpdateDescription(command.NewDescription);

        await _repository.UpdateAsync(article, cancellationToken);

        return Result.Success();
    }
}
