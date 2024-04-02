using Bookflix.Domain.Common.Errors;
using BuberDinner.Domain.Common.Models;
using ErrorOr;

namespace Bookflix.Domain.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; private set; }

    public Rating() { }
    public Rating(double value)
    {
        Value = value;
    }

    public static ErrorOr<Rating> Create(double value)
    {
        if (value < 0 || value > 5)
        {
            return Errors.Rating.InvalidRating;
        }

        return new Rating(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}