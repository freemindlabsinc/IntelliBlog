using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Types;

public class BlogNode : ObjectTypeExtension<Blog>
{
    //[UsePaging]
    //[HotChocolate.Types.UseFiltering]
    //[HotChocolate.Types.UseSorting]
    //public IQueryable<Post> GetPosts(
    //        [Parent] 
    //        Blog blog,  

    //        [Service(ServiceKind.Synchronized)]
    //        IEntityRepository<Post> repository)
    //{
    //    return repository.Source
    //        .Where(p => p.BlogId == blog.Id);
    //}

    protected override void Configure(IObjectTypeDescriptor<Blog> descriptor)
    {
        base.Configure(descriptor);

        descriptor.BindFieldsExplicitly();
        //descriptor.Field("DummyField")
        //          .Resolve(() => "Blog-DummyFieldValue");
    }

    [DataLoader]
    internal static async Task<Blog> GetBlogByIdAsync(
        [ID(nameof(Blog))] int id,
        IBlogByIdDataLoader blogById,
        CancellationToken cancellationToken)

        => await blogById.LoadAsync(id, cancellationToken);

    [DataLoader]
    internal static async Task<IEnumerable<Blog>> GetBlogsById(
        [ID(nameof(Blog))] int[] ids,
        IBlogByIdDataLoader blogById,
        IEntityRepository<Blog> repository,
        CancellationToken cancellationToken)
    
        => await blogById.LoadAsync(ids, cancellationToken);
}
