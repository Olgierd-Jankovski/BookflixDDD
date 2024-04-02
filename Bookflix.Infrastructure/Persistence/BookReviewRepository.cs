using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookReviewAggregate;

namespace Bookflix.Infrastructure.Persistence;

public class BookReviewRepository : IBookReviewRepository
{
    private readonly AppDbContext _context;

    public BookReviewRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BookReview?> GetBookReviewById(int id, CancellationToken cancellationToken)
    {
        return await _context.BookReviews.FindAsync(id, cancellationToken);
    }
    
}