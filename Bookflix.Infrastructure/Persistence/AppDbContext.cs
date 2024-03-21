using Bookflix.Domain.AuthorAggregate;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.BookAggregate.Entities;
using Bookflix.Domain.BookReviewAggregate;
using Bookflix.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bookflix.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }

    public DbSet<Author> Authors {get; set;} = null!;
    public DbSet<Book> Books {get; set;} = null!;
    public DbSet<BookGenre> BookGenres {get; set;} = null!;
    public DbSet<BookReview> BookReviews {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new BookReviewEntityTypeConfiguration());
    }
}