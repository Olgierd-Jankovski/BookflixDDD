using Bookflix.Application.Common.Interfaces.Services;

namespace Bookflix.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}