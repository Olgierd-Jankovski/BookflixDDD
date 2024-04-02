using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.AuthorAggregate;

namespace Bookflix.Infrastructure.Persistence;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Author author)
    {
        _context.Authors.Add(author);

        return Task.CompletedTask;
    }

    public async Task<Guid?> GetIdentityGuid(int authorId)
    {
        var author = await _context.Authors.FindAsync(authorId);

        return author?.IdentityGuid;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}