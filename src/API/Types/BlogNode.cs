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
    internal static async Task<IReadOnlyDictionary<int, Blog>> GetBlogsByIdAsync(
        IReadOnlyList<int> ids,
        IEntityRepository<Blog> repository,
        CancellationToken cancellationToken)

        => await repository.Source
            .Where(a => ids.Contains(a.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
}
