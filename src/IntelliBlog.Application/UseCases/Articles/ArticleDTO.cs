using IntelliBlog.Domain.Article;

namespace IntelliBlog.Application.UseCases.Articles;

public record ArticleDTO(ArticleId id, string title, string content);
