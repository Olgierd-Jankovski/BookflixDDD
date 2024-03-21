using BuberDinner.Domain.Common.Models;

namespace Bookflix.Domain.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; private set; }

    public Rating() { }
    public Rating(double value)
    {
        if (value < 0 || value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Rating must be between 0 and 5");
        }

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}