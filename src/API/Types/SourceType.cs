using API.DataLoaders;

namespace API.Types;

public class SourceType : ObjectType<Source>
{
    protected override void Configure(IObjectTypeDescriptor<Source> descriptor)
    {
        descriptor.Field(t => t.BlogId).Ignore();
        descriptor.Field("blog")
            .Resolve(async context =>
            {
                var key = context.Parent<Source>().BlogId;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<BlogDataLoader>().LoadAsync(key, cancellationToken);
            })
            .Type<NonNullType<SourceType>>();

        
        descriptor.Field("posts")
            .Resolve(async context =>
            {
                var key = context.Parent<Source>().Id;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<SourcePostsDataLoader>().LoadAsync(key, cancellationToken);
            })          
            .Type<NonNullType<ListType<PostType>>>();
    }    
}
