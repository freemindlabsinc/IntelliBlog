using Blogging.Domain.Interfaces;

namespace GraphQL.Blogs;

public class BlogExtensions : ObjectTypeExtension<Blog>
{
    [ExtendObjectType<Blog>()]
    public class NewBlogFields
    {
        public IEnumerable<string>? GetExtraStuff([Parent] Blog blog)
        {
            return new List<string> { "extra1", "extra2" };
        }

        [UsePaging]
        [HotChocolate.Data.UseFiltering]
        [HotChocolate.Data.UseSorting]
        public IQueryable<Post> GetPosts(
            [Parent] Blog blog,
            [Service(ServiceKind.Synchronized)] IEntityRepository<Post> repository)
        {
            return repository.Source
                .Where(p => p.BlogId == blog.Id);            
        }
    }

    protected override void Configure(IObjectTypeDescriptor<Blog> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id).ID();                
    }    
}

