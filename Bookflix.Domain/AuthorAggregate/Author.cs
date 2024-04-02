using Bookflix.Domain.Common.Models;
using Bookflix.Domain.AuthorAggregate;
using System.ComponentModel.DataAnnotations;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.Common.Entities;

namespace Bookflix.Domain.AuthorAggregate;

public sealed class Author : Entity<int>, IAggregateRoot
{
    public Guid IdentityGuid { get; private set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeInfo DateTimeInfo { get; private set; }

    private readonly List<Book> _books = new();
    public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    public Author(string firstName, string lastName)
        : base(default)
    {
        FirstName = firstName;
        LastName = lastName;
        DateTimeInfo = new DateTimeInfo();
    }

    public static Author Create(string firstName, string lastName)
    {
        var author = new Author(firstName, lastName);
        author.IdentityGuid = Guid.NewGuid();
        return author;
    }


}
