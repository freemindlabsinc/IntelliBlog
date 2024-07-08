using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.Create;

public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand, Result<ArticleId>>
{
    private readonly IRepository<Article> _repository;

    public CreateArticleCommandHandler(IRepository<Article> repository)
    {
        _repository = repository;
    }

    public async Task<Result<ArticleId>> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
    {
        var article = Article.CreateNew(command.BlogId, command.Title, command.Description);
        
        article.UpdateText(command.Text);
        if (command.Tags != null)
        {
            article.AddTags(command.Tags);
        }        

        await _repository.AddAsync(article, cancellationToken);

        return Result.Success(article.Id);
    }
}
