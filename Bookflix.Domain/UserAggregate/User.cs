using Bookflix.Domain.AuthorAggregate;
using Bookflix.Domain.Common.Models;

namespace Bookflix.Domain.UserAggregate;

public sealed class User : Entity<int>, IAggregateRoot
{
    // make optional authorId
    public int? AuthorId { get; private set; }
    public Author? Author { get; private set; }
    public Guid UserIdentityGuid { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public User(string firstName, string lastName, string email, string password)
        : base(default)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        var user = new User(firstName, lastName, email, password);
        user.UserIdentityGuid = Guid.NewGuid();
        return user;
    }

    public void SetAuthor(Author author)
    {
        Author = author;
        AuthorId = author.Id;
    }
}