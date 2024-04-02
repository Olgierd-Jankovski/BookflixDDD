using Bookflix.Domain.Common.Models;

namespace Bookflix.Domain.BookReviewAggregate.Events;

public record BookReviewAddedDomainEvent(BookReview BookReview) : IDomainEvent;
