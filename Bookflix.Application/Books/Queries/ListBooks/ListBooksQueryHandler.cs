using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookAggregate;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Books.Queries.ListBooks
{
    public class ListBooksQueryHandler : IRequestHandler<ListBooksQuery, ErrorOr<List<Book>>>
    {
        private readonly IBookRepository _bookRepository;

        public ListBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<List<Book>>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.ToListAsync(request.AuthorId, cancellationToken);
        }
    }
}