using Bookflix.Domain.BookReviewAggregate;
using Bookflix.Domain.ValueObjects;
using Bookflix.Infrastructure.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookflix.Infrastructure.EntityConfigurations;

class BookReviewEntityTypeConfiguration : IEntityTypeConfiguration<BookReview>
{
    public void Configure(EntityTypeBuilder<BookReview> bookReviewConfigurations)
    {
        // Map Rating value object to a database column
        bookReviewConfigurations.Property(b => b.Rating)
            .HasColumnName("Rating")
            .HasConversion(
                v => v.Value,          // Convert Rating to double
                v => new Rating(v)     // Convert double to Rating
            );

        // Map DateTimeInfo value object to a database column
        var dateTimeInfoConfig = new DateTimeInfoConfigurations<BookReview>(b => b.DateTimeInfo);
        dateTimeInfoConfig.Configure(bookReviewConfigurations);
    }
}