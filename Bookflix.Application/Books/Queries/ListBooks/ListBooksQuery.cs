using Bookflix.Domain.BookAggregate;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Queries.ListBooks
{
    public record ListBooksQuery(int? AuthorId)
        : IRequest<ErrorOr<List<Book>>>;
}