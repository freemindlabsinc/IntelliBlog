using Blogging.Domain.Interfaces;

namespace GraphQL.Posts;

[QueryType]
public static class PostsQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public static IQueryable<Post> GetPosts([Service(ServiceKind.Synchronized)] IEntityRepository<Post> repository)
        => repository.Source;

    public static async Task<Ardalis.Result.Result<Post>> GetPostByIdAsync(
        [Service(ServiceKind.Synchronized)] IEntityRepository<Post> repository,
        [GraphQLType(typeof(IdType))] int id)
        => await repository.GetByIdAsync(id);
}
