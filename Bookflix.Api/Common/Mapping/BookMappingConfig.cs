using Bookflix.Application.Books.Commands.CreateBook;
using Bookflix.Contracts.Books;
using Bookflix.Domain.BookAggregate;
using Bookflix.Domain.BookAggregate.Entities;
using Mapster;

namespace Bookflix.Api.Common.Mapping;

public class BookMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateBookRequest Request, int AuthorId), CreateBookCommand>()
            .Map(dest => dest.AuthorId, src => src.AuthorId)
            .Map(dest => dest, src => src.Request);
        
    }
}