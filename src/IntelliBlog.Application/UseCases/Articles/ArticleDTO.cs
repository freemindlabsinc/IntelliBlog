using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Application.UseCases.Articles;

public record ArticleDTO(ArticleId id, string title, string content);
