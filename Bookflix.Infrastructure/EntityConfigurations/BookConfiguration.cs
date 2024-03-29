using Bookflix.Domain.AuthorAggregate;
using Bookflix.Domain.BookAggregate;
using Bookflix.Infrastructure.EntityConfiguration.Common;
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
        builder.HasMany(b => b.Reviews)
            .WithOne(r => r.Book)
            .HasForeignKey(r => r.BookId);

        // Map DateTimeInfo value object to a database column
        var dateTimeConfig = new DateTimeInfoConfigurations<Book>(b => b.DateTimeInfo);
        dateTimeConfig.Configure(builder);

    }
}

