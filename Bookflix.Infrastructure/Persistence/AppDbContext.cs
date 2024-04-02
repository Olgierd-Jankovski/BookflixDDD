using Bookflix.Domain.AuthorAggregate;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.BookAggregate.Entities;
using Bookflix.Domain.BookReviewAggregate;
using Bookflix.Domain.Common.Models;
using Bookflix.Domain.UserAggregate;
using Bookflix.Infrastructure.EntityConfigurations;
using Bookflix.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Bookflix.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
    : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<BookGenre> BookGenres { get; set; } = null!;
    public DbSet<BookReview> BookReviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ignore the domain events property from the model
        // we will never want to store a list of domain events in the database
        modelBuilder.Ignore<List<IDomainEvent>>();

        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new BookReviewEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}