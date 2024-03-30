using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookAggregate;

namespace Bookflix.Infrastructure.Persistence;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);

        _context.SaveChanges();
        // we do not want to save the changes, only check out how the book is added to the context
    }

    /*private static readonly List<Book> _books = new();

    public void Add(Book book)
    {
        _books.Add(book);
    } */
}