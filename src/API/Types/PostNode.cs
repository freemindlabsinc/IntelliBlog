using Microsoft.EntityFrameworkCore;

namespace GraphQL.Types;

[Node]
//[ExtendObjectType<Article>]
public class PostNode : ObjectTypeExtension<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
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
        descriptor.Field("Number")
                  .Resolve((ctx, ct) => 
                  {
                      return GetNumber(ctx.Parent<Post>());
                  });
    }

    [BindMember("Number")]
    public static int GetNumber([Parent] Post article)
    {
        return article.Id * 10000;
    }

    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Post>> GetArticleByIdAsync(
        IReadOnlyList<int> ids,
        AppDbContext context,
        CancellationToken cancellationToken) 
        => await context.Posts
            .Where(a => ids.Contains(a.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
}
