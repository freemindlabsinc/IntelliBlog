namespace IntelliBlog.Application.UseCases.Articles.AddLike;
public readonly record struct LikeArticleCommand(
    ArticleId ArticleId,
    string LikedBy) 
    : ICommand<Result<int>>;
