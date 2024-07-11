using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.Create;

public class CreateArticleCommandHandler(IRepository<Article> _repository) : 
    ICommandHandler<CreateArticleCommand, Result<ArticleId>>
{
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
