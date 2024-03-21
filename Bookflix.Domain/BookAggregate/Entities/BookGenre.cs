using System.ComponentModel.DataAnnotations;
using Bookflix.Domain.BookAggregate.Enums;
using Bookflix.Domain.Common.Models;

namespace Bookflix.Domain.BookAggregate.Entities
{
    public class BookGenre : Entity<int>
    {

        [Required]
        public Genre Genre { get; private set; }

        // Foreign key to the Book entity
        public int BookId { get; private set; }

        // Navigation property to the Book entity
        public Book Book { get; private set; } = null!;
        public BookGenre(int id, Genre genre, int bookId) : base(id)
        {
            Genre = genre;
            BookId = bookId;
        }
    }
}