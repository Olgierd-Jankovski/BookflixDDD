using Bookflix.Domain.BookReviewAggregate;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Commands.AddBookReview;

public record AddBookReviewCommand(
    int BookId,
    double Rating,
    string? Comment,
    int UserId
) : IRequest<ErrorOr<BookReview>>;