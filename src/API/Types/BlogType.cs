namespace API.Types;

public class BlogType : ObjectType<Blog>
{
    protected override void Configure(IObjectTypeDescriptor<Blog> descriptor)
    {

        descriptor.Field("Posts")
            .Resolve(async context =>
            { 
                var key = context.Parent<Blog>().Id;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<BlogPostsDataLoader>().LoadAsync(key, cancellationToken);
            })
            .Name("posts")
            .Type<NonNullType<ListType<PostType>>>();
    }

}
