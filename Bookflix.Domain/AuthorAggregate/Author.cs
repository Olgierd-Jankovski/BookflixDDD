using Bookflix.Domain.Common.Models;
using Bookflix.Domain.AuthorAggregate;
using System.ComponentModel.DataAnnotations;
using Bookflix.Domain.BookAggregate;

namespace Bookflix.Domain.AuthorAggregate;

public sealed class Author : Entity<int>, IAggregateRoot
{

    public Guid IdentityGuid { get; private set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    private readonly List<Book> _books = new();
    public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    public Author(string firstName, string lastName)
        : base(default)
    {
        FirstName = firstName;
        LastName = lastName;
        CreatedDateTime = DateTime.Now;
        UpdatedDateTime = DateTime.Now;
    }

    public static Author Create(string firstName, string lastName)
    {
        var author = new Author(firstName, lastName);
        author.IdentityGuid = Guid.NewGuid();
        return author;
    }


}
