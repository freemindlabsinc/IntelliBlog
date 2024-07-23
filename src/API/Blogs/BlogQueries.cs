using Blogging.Domain.Interfaces;

namespace API.Blogs;

[QueryType]
public static class BlogQueries
{
    [UsePaging]
    //[UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Blog> GetBlogs(
        [Service] 
        IEntityRepository<Blog> repository)
        
        => repository.Source;

    public static async Task<Blog?> GetBlogByIdAsync(
        [Service] 
        IEntityRepository<Blog> repository,

        [GraphQLType(typeof(IdType))] 
        int id)

        => await repository.GetByIdAsync(id);
                
}
