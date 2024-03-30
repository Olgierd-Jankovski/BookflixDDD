using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.UserAggregate;

namespace Bookflix.Infrastructure.Persistence.userRepository;

public class UserRepository : IUserRepository
{
    //private static readonly List<User> _users = new();
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(u => u.Email ==  email);
    }

    public User? GetUserById(int id)
    {
        return _context.Users.SingleOrDefault(u => u.Id == id);
    }
}