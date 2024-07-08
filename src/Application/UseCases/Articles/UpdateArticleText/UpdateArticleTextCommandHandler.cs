using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.Update;

public class UpdateArticleTextCommandHandler(
    IRepository<Article> _repository)
    : ICommandHandler<UpdateArticleTextCommand, Result>
{    
    public async Task<Result> Handle(UpdateArticleTextCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.ArticleId);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
            return Result.NotFound();

        article.UpdateText(command.Description);
        article.UpdateText(command.Text);
        await _repository.UpdateAsync(article, cancellationToken);

        return Result.Success();
    }
}
