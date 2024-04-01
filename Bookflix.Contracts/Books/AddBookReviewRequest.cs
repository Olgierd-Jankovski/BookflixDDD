namespace Bookflix.Contracts.Books;

public record AddBookReviewRequest(
    int BookId,
    double Rating,
    string? Comment
);