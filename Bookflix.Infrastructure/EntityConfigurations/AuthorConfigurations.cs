using Bookflix.Domain.AuthorAggregate;
using Bookflix.Infrastructure.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookflix.Infrastructure.EntityConfigurations;

class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        // Map DateTimeInfo value object to a database column
        var dateTimeConfig = new DateTimeInfoConfigurations<Author>(a => a.DateTimeInfo);
        dateTimeConfig.Configure(builder);
    }
}