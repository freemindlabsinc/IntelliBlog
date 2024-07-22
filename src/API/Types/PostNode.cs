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
    internal static async Task<Post> GetPostByIdAsync(
        [ID(nameof(Post))] int id,
        IPostByIdDataLoader postById,
        CancellationToken cancellationToken)

        => await postById.LoadAsync(id, cancellationToken);

    [DataLoader]
    internal static async Task<IEnumerable<Post>> GetPostsByIdAsync(
        [ID(nameof(Post))] int[] ids,
        IPostByIdDataLoader postById,
        IEntityRepository<Post> repository,
        CancellationToken cancellationToken)

        => await postById.LoadAsync(ids, cancellationToken);

    [DataLoader]
    internal static async Task<IEnumerable<Post>> GetPostsByBlogIdAsync(
        [ID(nameof(Blog))] int blogId,
        IEntityRepository<Post> postRepository,
        PostsByIdDataLoader postsById,
        CancellationToken cancellationToken)
    {
        int[] postIds = await postRepository.Source
            .Where(p => p.BlogId == blogId)
            .Select(p => p.Id)
            .ToArrayAsync();

        return await postsById.LoadAsync(postIds, cancellationToken);
    }

    [DataLoader]
    internal static async Task<IEnumerable<Post>> GetPostsByBlogIdsAsync(
            [ID(nameof(Blog))] int[] blogIds,
            IEntityRepository<Post> postRepository,
            PostsByIdDataLoader postsById,
            CancellationToken cancellationToken)
    {
        int[] postIds = await postRepository.Source
            .Where(p => blogIds.Contains(p.BlogId))
            .Select(p => p.Id)
            .ToArrayAsync();

        return await postsById.LoadAsync(postIds, cancellationToken);
    }
}
