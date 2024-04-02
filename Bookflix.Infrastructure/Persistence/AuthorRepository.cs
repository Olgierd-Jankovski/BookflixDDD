using Bookflix.Application.Common.Interfaces.Persistence;

namespace Bookflix.Infrastructure.Persistence;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid?> GetIdentityGuid(int authorId)
    {
        var author = await _context.Authors.FindAsync(authorId);

        return author?.IdentityGuid;
    }
}