namespace Bookflix.Contracts.Books;

public record BookResponse(
    int Id,
    int AuthorId,
    string Title,
    string Description,
    double AverageRating,
    List<GenreResponse> Genres,
    List<BookReviewResponse> Reviews,

    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record GenreResponse(
    int Id,
    string Name
);

public record BookReviewResponse(
    int Id,
    double Rating,
    string Comment,
    Guid AuthorIdentityGuid,
    int BookId
);