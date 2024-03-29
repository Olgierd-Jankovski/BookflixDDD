using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookAggregate;

namespace Bookflix.Infrastructure.Persistence;

public class BookRepository : IBookRepository
{
    /*private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
    }*/

    private static readonly List<Book> _books = new();

    public void Add(Book book)
    {
        _books.Add(book);
    }
}