using Blogging.Domain.Aggregates.Articles;

namespace GraphQL.Articles;

public class ArticleCommentExtensions : ObjectTypeExtension<ArticleComment>
{
    protected override void Configure(IObjectTypeDescriptor<ArticleComment> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id).ID();
        descriptor.Ignore(x => x.ArticleId);
    }
}
