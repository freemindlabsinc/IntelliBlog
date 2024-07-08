namespace Blogging.Application.UseCases.Articles.RemoveTags;
public readonly record struct RemoveTagsCommand(
    ArticleId Id,
    string[] TagsToRemove
    ) : ICommand<Result<int>>;
