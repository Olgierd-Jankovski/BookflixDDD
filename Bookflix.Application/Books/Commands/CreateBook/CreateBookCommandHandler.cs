using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookAggregate;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Commands.CreateBook;

public class CreateBookCOmmandHandler : IRequestHandler<CreateBookCommand, ErrorOr<Book>>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCOmmandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create a new book
        var book = Book.Create(
            authorId: request.AuthorId,
            title: request.Title,
            description: request.Description
        );

        // add genres
        foreach (var genre in request.Genres)
        {
            book.AddGenre(genre.Genre);
        }

        // save the book
        _bookRepository.Add(book);

        return book;
    }
}