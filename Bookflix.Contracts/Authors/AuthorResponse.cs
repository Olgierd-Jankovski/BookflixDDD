namespace Bookflix.Contracts.Authors;

public record AuthorResponse(
    int Id,
    int UserId,
    string FirstName,
    string LastName,
    int AmountOfBooks,
    DateTime CreatedAt,
    DateTime UpdatedAt
);