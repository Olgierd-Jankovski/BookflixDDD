using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.BookReviewAggregate.Events;
using MediatR;

namespace Bookflix.Application.Books.Events;

public class BookReviewAddedDomainEventHandler : INotificationHandler<BookReviewAddedDomainEvent>
{
    private readonly IBookReviewRepository _bookReviewRepository;
    private readonly IBookRepository _bookRepository;

    public BookReviewAddedDomainEventHandler(IBookReviewRepository bookReviewRepository, IBookRepository bookRepository)
    {
        _bookReviewRepository = bookReviewRepository;
        _bookRepository = bookRepository;
    }

    public async Task Handle(BookReviewAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        var bookReview = await _bookReviewRepository.GetBookReviewById(notification.BookReview.Id, cancellationToken)
            ?? throw new InvalidOperationException();

        var book = await _bookRepository.GetBookByIdAsync(bookReview.BookId.Value, cancellationToken)
            ?? throw new InvalidOperationException();

        book.UpdateAverageRating(bookReview.Rating);

        await _bookRepository.SaveChangesAsync(cancellationToken);
    }
}
