namespace Bookflix.Application.Common.Interfaces.Persistence;

using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.Entities;

public interface IBookRepository
{
    void Add(Book book);
}