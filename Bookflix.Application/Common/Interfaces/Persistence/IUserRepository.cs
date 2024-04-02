using Bookflix.Domain.UserAggregate;

namespace Bookflix.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetUserByEmail(string email);
    User? GetUserById(int id);
    Task<Guid?> GetIdentityGuid(int userId);
}