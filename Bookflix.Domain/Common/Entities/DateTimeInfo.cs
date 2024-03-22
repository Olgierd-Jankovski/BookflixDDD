using BuberDinner.Domain.Common.Models;

namespace Bookflix.Domain.Common.Entities;
public sealed class DateTimeInfo
{
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public DateTimeInfo()
    {
        CreatedDateTime = DateTime.Now;
        UpdatedDateTime = DateTime.Now;
    }

    public void Update()
    {
        UpdatedDateTime = DateTime.Now;
    }
}