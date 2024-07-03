using IntelliBlog.Domain.Articles;

namespace IntelliBlog.API.Application.UseCases.Articles.Create;

public class CreateArticleHandler(IRepository<Article> _repository)
  : ICommandHandler<CreateArticleCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateArticleCommand request,
      CancellationToken cancellationToken)
    {
        var newArticle = Article.CreateNew(new (request.BlogId), request.Title, request.Description, request.Text);
        var createdItem = await _repository.AddAsync(newArticle, cancellationToken);

        return createdItem.Id.Value;
    }
}
