using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Types;

//[ExtendObjectType<Post>]
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

        base.Configure(descriptor);
        descriptor.BindFieldsExplicitly();
        //descriptor.Field(x => x.Id).Type<IdType>();
        //descriptor.Ignore(x => x.BlogId);
        //descriptor.Ignore(x => x.CreatedBy);
        //descriptor.Ignore(x => x.CreatedOn);
        //descriptor.Field("Number")
        //          .Resolve((ctx, ct) => 
        //          {
        //              return GetNumber(ctx.Parent<Post>());
        //          });
    }

    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Post>> GetPostsByIdAsync(
        IReadOnlyList<int> ids,
        IEntityRepository<Post> repository,
        CancellationToken cancellationToken) 

        => await repository.Source
            .Where(a => ids.Contains(a.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
}
