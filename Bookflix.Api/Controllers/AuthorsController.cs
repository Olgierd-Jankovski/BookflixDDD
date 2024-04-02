using System.Security.Principal;
using Bookflix.Application.Common.Interfaces.Services;
using MapsterMapper;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Bookflix.Domain.AuthorAggregate;
using Bookflix.Contracts.Authors;
using Bookflix.Application.Authors.Commands;

namespace Bookflix.Api.Controllers;

[Route("[controller]")]
public class AuthorsController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly IIDentityService _identityService;

    public AuthorsController(ISender sender, IMapper mapper, IIDentityService identityService)
    {
        _sender = sender;
        _mapper = mapper;
        _identityService = identityService;
    }

    [HttpPost]
    public async Task<IActionResult> BecomeAuthor([FromBody] BecomeAuthorRequest request)
    {
        // extract user idenetity from jwt token
        int? userId = _identityService.GetUserId();

        if (userId == null)
        {
            return Unauthorized();
        }

        var command = _mapper.Map<CreateAuthorCommand>((request, userId.Value));

        var result = await _sender.Send(command);

        return result.Match(
            author => Ok(_mapper.Map<AuthorResponse>(author)),
            errors => Problem(errors)
        );

    }

}