using Blogging.Domain.Aggregates.Articles;

namespace Blogging.API.Application.UseCases.Articles.Create;

public class CreateArticleHandler(IRepository<Article> _repository)
  : ICommandHandler<CreateArticleCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateArticleCommand request,
      CancellationToken cancellationToken)
    {
        var newArticle = Article.CreateNew(
            request.BlogId,
            request.Title, request.Description, request.Text);
        var createdItem = await _repository.AddAsync(newArticle, cancellationToken);

        return createdItem.Id.Value;
    }
}
