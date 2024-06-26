using Bookflix.Domain.AuthorAggregate;

namespace Bookflix.Application.Common.Interfaces.Persistence
{
    public interface IAuthorRepository
    {
        Task<Guid?> GetIdentityGuid(int authorId);
        Task AddAsync(Author author);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}