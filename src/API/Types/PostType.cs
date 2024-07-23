using API.DataLoaders;

namespace API.Types;

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        // problem
        descriptor.Field(t => t.BlogId).Ignore();
        descriptor.Field("blog")
            .Resolve(async context =>
            { 
                var key = context.Parent<Post>().BlogId;
                var cancellationToken = context.RequestAborted;
                
                return await context.DataLoader<BlogDataLoader>().LoadAsync(key, cancellationToken);
            })
            .Type<NonNullType<BlogType>>();

        descriptor.Field("sources")
            .Resolve(async context =>
            {
                var key = context.Parent<Post>().Id;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<PostSourcesDataLoader>().LoadAsync(key, cancellationToken);
            })
            //.UseProjection()
            //.Name("posts")            
            .Type<NonNullType<ListType<SourceType>>>();
    }
  

}
