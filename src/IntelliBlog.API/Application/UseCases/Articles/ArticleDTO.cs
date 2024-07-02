using IntelliBlog.Domain.Articles;

namespace IntelliBlog.API.Application.UseCases.Articles;

public record ArticleDTO(ArticleId Id, string Title, string Content);
