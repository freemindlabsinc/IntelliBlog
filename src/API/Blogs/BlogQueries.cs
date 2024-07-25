using Blogging.Domain.Interfaces;

namespace API.Blogs;

[QueryType]
public static class BlogQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Blog> GetBlogs(
        [Service(ServiceKind.Synchronized)] 
        IEntityRepository<Blog> repository)
        
        => repository.Source;

    public static async Task<Blog?> GetBlogByIdAsync(
        [Service] 
        IEntityRepository<Blog> repository,

        [GraphQLType<IdType>] 
        int id)

        => await repository.GetByIdAsync(id);
                
}
