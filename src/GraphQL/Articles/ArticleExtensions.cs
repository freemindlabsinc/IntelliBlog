using Blogging.Domain.Aggregates.Articles;
using MediatR;

namespace GraphQL.Articles;

[Node]
public class ArticleExtensions : ObjectTypeExtension<Article>
{
    protected override void Configure(IObjectTypeDescriptor<Article> descriptor)
    {
        // By default it seems fields are implicitly mapped and that causes problems
        // when we inherit from HasDomainEventBase. Somehow the fact INotification 
        // is referenced triggers strawberry shake that complains INotification has no 
        // fields (which is true, since it's a marker interface)/
        // Surprisingly calling BindFieldsExplicitly maps all publish stuff anyway
        // but without the INotification problems. Ignore() can then be called afterwards.

        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id).Type<IdType>();
        descriptor.Ignore(x => x.BlogId);
        descriptor.Ignore(x => x.CreatedBy);
        descriptor.Ignore(x => x.CreatedOn);
    }
}
