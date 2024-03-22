using System.Linq.Expressions;
using Bookflix.Domain.Common.Entities;
using Bookflix.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookflix.Infrastructure.EntityConfiguration.Common;


// We are using the reflection to access the DateTimeInfo property dynamically
public class DateTimeInfoConfigurations<T> : IEntityTypeConfiguration<T> where T : Entity<int>
{
    private readonly Expression<Func<T, DateTimeInfo>> _dateTimeInfoSelector;

    public DateTimeInfoConfigurations(Expression<Func<T, DateTimeInfo>> dateTimeInfoSelector)
    {
        _dateTimeInfoSelector = dateTimeInfoSelector;
    }

    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.OwnsOne(_dateTimeInfoSelector, dateTimeInfo =>
        {
            dateTimeInfo.Property(di => di.CreatedDateTime);
            dateTimeInfo.Property(di => di.UpdatedDateTime);
        });
    }
}