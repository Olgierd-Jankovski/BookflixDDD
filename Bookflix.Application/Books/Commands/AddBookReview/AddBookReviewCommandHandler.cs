using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookReviewAggregate;
using Bookflix.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Commands.AddBookReview;

public class AddBookReviewCommandHandler : IRequestHandler<AddBookReviewCommand, ErrorOr<BookReview>>
{
    private readonly IBookRepository _bookRepository;

    public AddBookReviewCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<BookReview>> Handle(AddBookReviewCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(request.BookId);

        if (book is null)
        {
            return Error.NotFound("Book not found");
        }

        var reviewerId = new Guid(); // Replace with the actual reviewer's identity guid
        var authorId = new Guid(); // Replace with the actual author's identity guid
        //var review = book.AddReview(new Rating(request.Rating), request.Comment, authorId);
        ErrorOr<Rating> rating = Rating.Create(request.Rating);
        if (rating.IsError)
        {
            return rating.Errors;
        }        
        
        var review = book.AddReview(rating.Value, request.Comment, authorId, reviewerId);

        await _bookRepository.SaveChangesAsync(cancellationToken);

        return review;
    }
}
