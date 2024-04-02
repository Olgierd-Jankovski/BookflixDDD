namespace Bookflix.Domain.Common.Errors;
using ErrorOr;

public static partial class Errors
{
    public static class Book
    {
        public static Error AuthorHasAlreadyReviewedTheBook => Error.Conflict(
            code: "Book.AuthorHasAlreadyReviewedTheBook",
            description: "Author has already reviewed the book");

    }
}