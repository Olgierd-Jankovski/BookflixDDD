namespace Bookflix.Application.Common.Interfaces.Persistence;

using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.Entities;

public interface IBookRepository
{
    void Add(Book book);
    Book GetBookById(int bookId);
    Task<Book> GetBookByIdAsync(int bookId);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<List<Book>> ToListAsync(int? authorId, CancellationToken cancellationToken);

}