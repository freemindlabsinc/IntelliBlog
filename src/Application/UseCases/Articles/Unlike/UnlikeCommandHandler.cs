using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.RemoveLike;

public class UnlikeCommandHandler(
    IRepository<Article> _repository) : ICommandHandler<UnlikeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UnlikeCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.ArticleId);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
        {
            return Result.NotFound();
        }

        article.Unlike(command.likedBy);
        await _repository.UpdateAsync(article, cancellationToken);

        return Result<int>.Success(article.Likes.Count);
    }
}
