namespace Blogging.Application.UseCases.Articles.RemoveLike;

public readonly record struct UnlikeCommand(ArticleId ArticleId)
    : ICommand<Result<int>>;
