using Ardalis.SharedKernel;

namespace Blogging.Application.UseCases.Articles.RemoveLike;

public readonly record struct UnlikeCommand(
    ArticleId ArticleId,
    string likedBy)
    : ICommand<Result<int>>;
