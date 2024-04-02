using Bookflix.Domain.BookReviewAggregate;

namespace Bookflix.Application.Common.Interfaces.Persistence;

public interface IBookReviewRepository
{
    Task<BookReview?> GetBookReviewById(int id, CancellationToken cancellationToken);
}