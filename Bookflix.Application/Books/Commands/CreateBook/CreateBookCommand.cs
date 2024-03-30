using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.BookAggregate.Entities;
using Bookflix.Domain.BookAggregate.Enums;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(
        string Title,
        string Description,
        int AuthorId,
        int UserId,
        List<BookGenreCommand> Genres
    ) : IRequest<ErrorOr<Book>>;

    public record BookGenreCommand(
        Genre Genre
    );

}