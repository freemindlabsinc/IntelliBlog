using Blogging.Domain;
using Infrastructure2.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Blogs;

[QueryType]
public class BlogQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public IQueryable<Blog> GetBlogs([Service(ServiceKind.Synchronized)] AppDbContext db)
        => db.Blogs;

    public Task<Blog?> GetBlogById([Service(ServiceKind.Synchronized)] AppDbContext db,
        [GraphQLType(typeof(IdType))] int id)
        => db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
}
