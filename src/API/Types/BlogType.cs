using API.DataLoaders;

namespace API.Types;

public class BlogType : ObjectType<Blog>
{
    protected override void Configure(IObjectTypeDescriptor<Blog> descriptor)
    {
        // correct
        descriptor.Field("posts")
            .Resolve(async context =>
            {
                var parent = context.Parent<Blog>();
                var key = parent.Id;
                var cancellationToken = context.RequestAborted;

                Post[] results = await context.DataLoader<BlogPostsDataLoader>().LoadAsync(key, cancellationToken);

                return results;
            })
            //.IsProjected(true)
            //.Name("posts")            
            .Type<NonNullType<ListType<PostType>>>()
            //.UseSorting()
            ;

        // correct
        descriptor.Field("sources")
            .Resolve(async context =>
            {
                var key = context.Parent<Blog>().Id;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<BlogSourcesDataLoader>().LoadAsync(key, cancellationToken);
            })
            //.UseProjection()
            //.Name("posts")            
            .Type<NonNullType<ListType<SourceType>>>();


    }

}
