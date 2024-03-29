using Bookflix.Application.Books.Commands.CreateBook;
using Bookflix.Contracts.Books;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookflix.Api.Controllers;

[AllowAnonymous]
[Route("[controller]")]
public class BooksController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public BooksController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("{authorId}")]
    public async Task<IActionResult> Create(CreateBookRequest request, int authorId)
    {
        var command = _mapper.Map<CreateBookCommand>((request, authorId));

        var result = await _sender.Send(command);

        return result.Match(
            book => Ok(_mapper.Map<BookResponse>(book)),
            errors => Problem(errors)
        );
    }

}