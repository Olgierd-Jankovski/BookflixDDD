using Bookflix.Domain.Common.Models;
using Bookflix.Domain.AuthorAggregate;
using System.ComponentModel.DataAnnotations;
using Bookflix.Domain.BookAggregate.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Bookflix.Domain.BookReviewAggregate;

namespace Bookflix.Domain.BookAggregate;

public sealed class Book : Entity<int>, IAggregateRoot
{
    public int? AuthorId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public double AverageRating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private readonly List<BookGenre> _genres;
    public IReadOnlyCollection<BookGenre> Genres => _genres.AsReadOnly();
    private readonly List<BookReview> _reviewIds;
    public IReadOnlyCollection<BookReview> ReviewIds => _reviewIds.AsReadOnly();

    public Book(int id, int? authorId, string title, string description, double averageRating) : base(id)
    {
        AuthorId = authorId;
        Title = title;
        Description = description;
        AverageRating = averageRating;
        CreatedDateTime = DateTime.Now;
        UpdatedDateTime = DateTime.Now;
        _genres = new List<BookGenre>();
        _reviewIds = new List<BookReview>();
    }

    public static Book Create(int authorId, string title, string description, double averageRating)
    {
        var book = new Book(default, authorId, title, description, averageRating);
        return book;
    }

    public void AddGenre(BookGenre genre)
    {
        _genres.Add(genre);
    }

    public void AddBookReview(BookReview review)
    {
        _reviewIds.Add(review);
    }
}