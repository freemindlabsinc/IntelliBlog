using Blogging.Domain.Interfaces;

namespace GraphQL.Blogs;

[QueryType]
public static class BlogQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public static IQueryable<Blog> GetBlogs([Service(ServiceKind.Synchronized)] IEntityRepository<Blog> repository)
        => repository.Source;

    public static async Task<Ardalis.Result.Result<Blog>> GetBlogByIdAsync(
        [Service(ServiceKind.Synchronized)] IEntityRepository<Blog> repository,
        [GraphQLType(typeof(IdType))] int id)
        => await repository.GetByIdAsync(id);
                
}
