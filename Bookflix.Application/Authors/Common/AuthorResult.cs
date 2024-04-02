namespace Bookflix.Application.Authors.Common
{
    public record AuthorResult(
        int Id,
        int UserId,
        string FirstName,
        string LastName,
        int AmountOfBooks,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}