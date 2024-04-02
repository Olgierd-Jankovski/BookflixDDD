using System.ComponentModel.DataAnnotations;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.Common.Entities;
using Bookflix.Domain.Common.Models;
using Bookflix.Domain.ValueObjects;

namespace Bookflix.Domain.BookReviewAggregate
{
    public class BookReview : Entity<int>, IAggregateRoot
    {
        // Rating is a Value Object 
        [Required]
        public Rating Rating { get; private set; }
        public Guid AuthorIdentityGuid { get; private set; }
        public Guid ReviewerIdentityGuid { get; private set; }
        public string? Comment { get; private set; }
        public DateTimeInfo DateTimeInfo { get; private set; }

        public Book Book { get; private set; }
        public int? BookId { get; private set; }

        public BookReview(int id, Rating rating, string? comment, Guid authorIdentityGuid, Guid reviewerIdentityGuid, int? bookId = null)
        : base(id)
        {
            Rating = rating;
            Comment = comment;
            AuthorIdentityGuid = authorIdentityGuid;
            ReviewerIdentityGuid = reviewerIdentityGuid;
            BookId = bookId;

            DateTimeInfo = new DateTimeInfo();
        }
    }
}