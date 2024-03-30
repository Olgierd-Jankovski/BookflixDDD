namespace Bookflix.Domain.Common.Errors;
using ErrorOr;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "User with the given email already exists");

        public static Error UnauthorizedAsAuthor => Error.Unauthorized(
            code: "User.UnauthorizedAsAuthor",
            description: "User is not authorized as an author");
    }
}