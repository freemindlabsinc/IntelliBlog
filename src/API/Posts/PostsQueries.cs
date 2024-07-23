using Blogging.Domain.Interfaces;

namespace API.Posts;

[QueryType]
public static class PostsQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Post> GetPosts(
        [Service] 
        IEntityRepository<Post> repository)

        => repository.Source;
    
    public static async Task<Post?> GetPostByIdAsync(
        [Service] 
        IEntityRepository<Post> repository,

        [GraphQLType<IdType>] 
        int id)

        => await repository.GetByIdAsync(id);
}
