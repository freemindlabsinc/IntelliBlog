using IntelliBlog.Domain.Aggregates.Articles;

namespace IntelliBlog.Application.UseCases.Articles.Delete;

public readonly record struct DeleteArticleCommand(ArticleId Id) : ICommand<Result>;
