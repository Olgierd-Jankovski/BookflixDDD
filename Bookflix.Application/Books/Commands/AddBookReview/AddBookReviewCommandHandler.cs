using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookReviewAggregate;
using Bookflix.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Commands.AddBookReview;

public class AddBookReviewCommandHandler : IRequestHandler<AddBookReviewCommand, ErrorOr<BookReview>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthorRepository _authorRepository;

    public AddBookReviewCommandHandler(IBookRepository bookRepository, IUserRepository userRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _authorRepository = authorRepository;
    }

    public async Task<ErrorOr<BookReview>> Handle(AddBookReviewCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(request.BookId);

        if (book is null)
        {
            return Error.NotFound("Book not found");
        }

        var reviewerIdentityGuid = await _userRepository.GetIdentityGuid(request.UserId);
        var authorIdentityGuid = await _authorRepository.GetIdentityGuid(book.AuthorId.Value);

        if (reviewerIdentityGuid is null || authorIdentityGuid is null)
        {
            return Error.NotFound("User or author not found");
        }

        //var review = book.AddReview(new Rating(request.Rating), request.Comment, authorId);
        ErrorOr<Rating> rating = Rating.Create(request.Rating);
        if (rating.IsError)
        {
            return rating.Errors;
        }        
        
        var review = book.AddReview(rating.Value, request.Comment, authorIdentityGuid.Value, reviewerIdentityGuid.Value, request.UserId);

        if (review.IsError)
        {
            return review.Errors;
        }

        await _bookRepository.SaveChangesAsync(cancellationToken);

        return review;
    }
}
