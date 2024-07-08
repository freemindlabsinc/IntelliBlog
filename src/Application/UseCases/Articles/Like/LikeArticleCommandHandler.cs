using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.AddLike;

public class LikeArticleCommandHandler(
    IRepository<Article> _repository) 
    : ICommandHandler<LikeArticleCommand, Result<int>>
{
    public async Task<Result<int>> Handle(LikeArticleCommand command, CancellationToken cancellationToken)
    {
        var article = await _repository.GetByIdAsync(command.ArticleId, cancellationToken);
        if (article == null)
        {
            return Result<int>.NotFound("Article not found");
        }

        article.Like(command.LikedBy);

        await _repository.UpdateAsync(article, cancellationToken);

        return Result<int>.Success(article.Likes.Count);
    }
}
