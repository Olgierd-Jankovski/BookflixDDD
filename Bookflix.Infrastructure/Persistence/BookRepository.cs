using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;

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

    public Book GetBookById(int bookId)
    {
        return _context.Books.Find(bookId);
    }

    public async Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken = default)
    {
        var book = await _context.Books
            .Where(b => b.Id == bookId)
            .Include(b => b.Genres)
            .Include(b => b.Reviews)
            .SingleOrDefaultAsync();

        return book;
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Book>> ToListAsync(int? authorId, CancellationToken cancellationToken)
    {   
        var books = await _context.Books
            .Where(b => authorId == null || b.AuthorId == authorId)
            .Include(b => b.Genres)
            .Include(b => b.Reviews)
            .ToListAsync(cancellationToken);

        return books;
    }

    public async Task UpdateAsync(Book book, CancellationToken cancellationToken = default)
    {
        _context.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /*private static readonly List<Book> _books = new();

    public void Add(Book book)
    {
        _books.Add(book);
    } */
}