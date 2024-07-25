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
        [Service(ServiceKind.Synchronized)]
        IEntityRepository<Post> repository)

        => repository.Source;
    
    public static async Task<Post?> GetPostByIdAsync(
        [Service] 
        IEntityRepository<Post> repository,

        [GraphQLType<IdType>] 
        int id)

        => await repository.GetByIdAsync(id);
}

//[QueryType]
//public static class PostCommentsQueries
//{
//    [UsePaging]
//    [UseProjection]
//    [UseFiltering]
//    [UseSorting]
//    public static IQueryable<PostComment> GetPostComments(
//        [Service]
//        IEntityRepository<PostComment> repository)

//        => repository.Source;

//    public static async Task<PostComment?> GetPostCommentByIdAsync(
//        [Service]
//        IEntityRepository<PostComment> repository,

//        [GraphQLType<IdType>]
//        int id)

//        => await repository.GetByIdAsync(id);
//}

//[QueryType]
//public static class SourceCommentsQueries
//{
//    [UsePaging]
//    [UseProjection]
//    [UseFiltering]
//    [UseSorting]
//    public static IQueryable<SourceComment> GetSourceComments(
//        [Service]
//        IEntityRepository<SourceComment> repository)

//        => repository.Source;

//    public static async Task<SourceComment?> GetSourceCommentByIdAsync(
//        [Service]
//        IEntityRepository<SourceComment> repository,

//        [GraphQLType<IdType>]
//        int id)

//        => await repository.GetByIdAsync(id);
//}
