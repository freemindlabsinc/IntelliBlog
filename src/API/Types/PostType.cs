﻿namespace API.Types;

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Field(t => t.BlogId)
            .Name("blog")
            .Resolve(async context =>
            { 
                var key = context.Parent<Post>().BlogId;
                var cancellationToken = context.RequestAborted;
                
                return await context.DataLoader<BlogDataLoader>().LoadAsync(key, cancellationToken);
            })
            //.Serial()
            .Type<NonNullType<BlogType>>();
    }
  
}