using System.Security.Claims;
using Bookflix.Application.Books.Commands.AddBookReview;
using Bookflix.Application.Books.Commands.CreateBook;
using Bookflix.Application.Common.Interfaces.Services;
using Bookflix.Contracts.Books;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookflix.Api.Controllers;

[Route("[controller]")]
public class BooksController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    private readonly IIDentityService _identityService;

    public BooksController(ISender sender, IMapper mapper, IIDentityService identityService)
    {
        _sender = sender;
        _mapper = mapper;
        _identityService = identityService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request)
    {
        // extract user identity from jwt token
        int? userId = _identityService.GetUserId();

        if (userId is null)
        {
            return Unauthorized();
        }


        var command = _mapper.Map<CreateBookCommand>((request, userId.Value));

        var result = await _sender.Send(command);

        return result.Match(
            book => Ok(_mapper.Map<BookResponse>(book)),
            errors => Problem(errors)
        );
    }

    [HttpPost("{bookId}/reviews")]
    public async Task<IActionResult> AddReview(AddBookReviewRequest request)
    {
        // extract user identity from jwt token
        int? userId = _identityService.GetUserId();

        if (userId is null)
        {
            return Unauthorized();
        }

        var command = _mapper.Map<AddBookReviewCommand>((request, userId.Value));

        var result = await _sender.Send(command);

        return result.Match(
            review => Ok(_mapper.Map<BookReviewResponse>(review)),
            errors => Problem(errors)
        );
    }

}