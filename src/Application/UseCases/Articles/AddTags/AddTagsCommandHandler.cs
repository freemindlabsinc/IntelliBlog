using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Application.UseCases.Articles.UpdateTags;

public class AddTagsCommandHandler(IRepository<Article> _repository)
    : ICommandHandler<AddTagsCommand, Result<int>>
{
    public async Task<Result<int>> Handle(AddTagsCommand command, CancellationToken cancellationToken)
    {
        var spec = new ArticleByIdSpec(command.Id);
        var article = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (article == null)
        {
            return Result.NotFound();
        }

        var removedTags = article.RemoveTags(command.NewTags);

        await _repository.UpdateAsync(article, cancellationToken);

        return Result.Success(article.Tags.Count);
    }
}
