using System.Reflection;
using Blogging.Infrastructure.Data.TestData;

namespace Blogging.Infrastructure.Data;
public class BloggingDbContext : DbContext
{
    public const string GlobalSequenceName = "General_seq"; // TODO: remove this global sequence and create as many as needed

    public BloggingDbContext(DbContextOptions<BloggingDbContext> options)
        : base(options)
    { }

    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();        
    public DbSet<PostComment> PostComments => Set<PostComment>();
    public DbSet<PostCommentLike> PostCommentsLikes => Set<PostCommentLike>();
    public DbSet<PostLike> PostLikes => Set<PostLike>();
    public DbSet<PostSource> PostSources => Set<PostSource>();
    public DbSet<Source> Sources => Set<Source>();
    public DbSet<SourceLike> SourceLikes => Set<SourceLike>();
    public DbSet<SourceComment> SourceComments => Set<SourceComment>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BloggingDbContext).Assembly);
                
        // TODO: create multiple sequences instead of just one
        // TODO: make sure each configuration type gets the right sequence automagically somehow
        modelBuilder.HasSequence<int>(GlobalSequenceName)
            .StartsAt(1)
            .IncrementsBy(1);

        //SetupBogusData(modelBuilder);
    }

}
