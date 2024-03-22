using Bookflix.Domain.AuthorAggregate;
using Bookflix.Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookflix.Infrastructure.EntityConfigurations;

class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasMany(b => b.Genres)
            .WithOne(bg => bg.Book)
            .HasForeignKey(bg => bg.BookId);

        // move to review ids
        builder.HasMany(b => b.ReviewIds)
            .WithOne(r => r.Book)
            .HasForeignKey(r => r.BookId);

    }
}

