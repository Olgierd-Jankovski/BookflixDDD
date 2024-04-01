using Bookflix.Application.Books.Commands.AddBookReview;
using Bookflix.Application.Books.Commands.CreateBook;
using Bookflix.Contracts.Books;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.BookAggregate.Entities;
using Bookflix.Domain.BookAggregate.Enums;
using Bookflix.Domain.BookReviewAggregate;
using Mapster;

namespace Bookflix.Api.Common.Mapping;

public class BookMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateBookRequest Request, int UserId), CreateBookCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<(AddBookReviewRequest Request, int UserId), AddBookReviewCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<GenreRequest, BookGenreCommand>()
            .Map(dest => dest.Genre, src => (Genre)src.GenreId);

        config.NewConfig<Book, BookResponse>()
            .Map(dest => dest.UpdatedAt, src => src.DateTimeInfo.UpdatedDateTime)
            .Map(dest => dest.CreatedAt, src => src.DateTimeInfo.CreatedDateTime)
            .Map(dest => dest.Genres, src => src.Genres.Select(g => new GenreResponse(g.Id, g.Genre.ToString())).ToList())
            //.Map(dest => dest.Reviews, src => src.Reviews.Select(r => new BookReviewResponse(r.Id, r.Rating.Value, r.Comment, r.AuthorIdentityGuid, 123)).ToList())
            .Map(dest => dest, src => src);

        config.NewConfig<BookReview, BookReviewResponse>()
            .Map(dest => dest.Rating, src => src.Rating.Value)
            .Map(dest => dest, src => src); 
    }
}