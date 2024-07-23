using API.DataLoaders;
using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Types;

public class SourceType : ObjectType<Source>
{
    protected override void Configure(IObjectTypeDescriptor<Source> descriptor)
    {
        // problem
        descriptor.Field(t => t.BlogId).Ignore();
        descriptor.Field("blog")
            .Resolve(async context =>
            {
                var key = context.Parent<Source>().BlogId;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<BlogDataLoader>().LoadAsync(key, cancellationToken);
            })
            .Type<NonNullType<SourceType>>();

        // correct
        descriptor.Field("posts")
            .Resolve(async context =>
            {
                var key = context.Parent<Source>().Id;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<SourcePostsDataLoader>().LoadAsync(key, cancellationToken);
            })
            //.UseProjection()
            //.Name("posts")            
            .Type<NonNullType<ListType<PostType>>>();
    }

    //[DataLoader]
    //internal static async Task<Source> GetSourceByIdAsync(
    //    [ID(nameof(Source))] int id,
    //    ISourceByIdDataLoader sourceById,
    //    CancellationToken cancellationToken)

    //    => await sourceById.LoadAsync(id, cancellationToken);

    //[DataLoader]
    //internal static async Task<IEnumerable<Source>> GetSourcesById(
    //    [ID(nameof(Source))] int[] ids,
    //    ISourceByIdDataLoader sourceById,
    //    IEntityRepository<Source> repository,
    //    CancellationToken cancellationToken)

    //    => await sourceById.LoadAsync(ids, cancellationToken);
}
