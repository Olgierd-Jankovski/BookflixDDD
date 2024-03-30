using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ErrorOr<Book>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository, IUserRepository userRepository)
    {
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Book>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate whether the user is authorized as an author
        var user = _userRepository.GetUserById(command.UserId);

        if(user.AuthorId != command.AuthorId)
        {
            return Errors.User.UnauthorizedAsAuthor;
        }

        // Create a new book
        var book = Book.Create(
            authorId: command.AuthorId,
            title: command.Title,
            description: command.Description
        );

        // add genres
        foreach (var genre in command.Genres)
        {
            book.AddGenre(genre.Genre);
        }

        // save the book
        _bookRepository.Add(book);

        return book;
    }
}