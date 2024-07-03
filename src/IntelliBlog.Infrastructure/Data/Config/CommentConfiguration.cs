using IntelliBlog.Domain.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliBlog.Infrastructure.Data.Config;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // Common
        builder.AddSequenceForId<Comment, CommentId>()
               .HasConversion(id => id.Value, value => new(value));

        //builder.AddTrackedEntityConfiguration<Comment, CommentId>();

        // Entity
        builder.Property(p => p.ArticleId)
               .HasConversion(id => id.Value, value => new ArticleId(value));

        //builder.Property(p => p.ParentId)
        //       .HasConversion(id => id ?? id.Value.Value : 0, value => new CommentId(value));

        builder
            .Property(p => p.Text)
            .IsRequired();

    }
}
