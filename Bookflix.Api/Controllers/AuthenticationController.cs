using Bookflix.Application.Authentication;
using Bookflix.Application.Authentication.Queries.Login;
using Bookflix.Application.Authentication.Commands.Register;
using Bookflix.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;

namespace Bookflix.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> authResult = await _sender.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        var query = _mapper.Map<LoginQuery>(request);

        ErrorOr<AuthenticationResult> authResult = await _sender.Send(query);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}