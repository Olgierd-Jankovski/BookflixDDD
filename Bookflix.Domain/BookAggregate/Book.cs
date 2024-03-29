using Bookflix.Domain.Common.Models;
using Bookflix.Domain.AuthorAggregate;
using System.ComponentModel.DataAnnotations;
using Bookflix.Domain.BookAggregate.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Bookflix.Domain.BookReviewAggregate;
using Bookflix.Domain.Common.Entities;
using Bookflix.Domain.BookAggregate.Enums;
using Bookflix.Domain.ValueObjects;

namespace Bookflix.Domain.BookAggregate;

public sealed class Book : Entity<int>, IAggregateRoot
{
    public int? AuthorId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public double AverageRating { get; private set; }
    public DateTimeInfo DateTimeInfo { get; private set; }

    private readonly List<BookGenre> _genres;
    public IReadOnlyCollection<BookGenre> Genres => _genres.AsReadOnly();
    private readonly List<BookReview> _reviews;
    public IReadOnlyCollection<BookReview> Reviews => _reviews.AsReadOnly();

    public Book(int id, int? authorId, string title, string description) : base(id)
    {
        AuthorId = authorId;
        Title = title;
        Description = description;
        AverageRating = new Rating(0).Value;
        _genres = new List<BookGenre>();
        _reviews = new List<BookReview>();
        DateTimeInfo = new DateTimeInfo();
    }

    public static Book Create(int authorId, string title, string description)
    {
        var book = new Book(default, authorId, title, description);
        return book;
    }

    public void AddGenre(Genre genre)
    {
        // check for duplicates
        if (_genres.Any(g => g.Genre == genre))
        {
            return;
        }
        var bookGenre = new BookGenre(default, genre, Id);
        _genres.Add(bookGenre);
    }

    public void AddBookReview(double rating, string comment, Guid authorIdentityGuid)
    {
        var bookReview = new BookReview(default, new Rating(rating), comment, authorIdentityGuid, Id);
        _reviews.Add(bookReview);
    }  
    
}