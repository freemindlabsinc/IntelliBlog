using System.Reflection;

namespace Blogging.Infrastructure.Data;
public class BloggingDbContext : DbContext
{
    public const string GlobalSequenceName = "General_seq"; // TODO: temporary

    private readonly IDomainEventDispatcher? _dispatcher;

    public BloggingDbContext(DbContextOptions<BloggingDbContext> options,
      IDomainEventDispatcher? dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

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
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
        modelBuilder.HasSequence<int>(GlobalSequenceName)
            .StartsAt(0)
            .IncrementsBy(1);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges() =>
          SaveChangesAsync().GetAwaiter().GetResult();
}
