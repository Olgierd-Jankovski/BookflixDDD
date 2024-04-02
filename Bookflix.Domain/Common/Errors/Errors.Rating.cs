using ErrorOr;

namespace Bookflix.Domain.Common.Errors;

public static partial class Errors
{
    public static class Rating
    {
        public static Error InvalidRating => Error.Validation(
            code: "Rating.InvalidRating",
            description: "Invalid rating, must be between 0 and 5");
    }
}