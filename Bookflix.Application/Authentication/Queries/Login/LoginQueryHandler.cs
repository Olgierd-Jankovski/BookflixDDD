using Bookflix.Application.Common.Interfaces.Authentication;
using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.Common.Errors;
using Bookflix.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;


    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Check user does not exist
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Check the password is correct
        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Generate jwt token
        var token = _jwtTokenGenerator.GenerateToken(
            user
        );

        return new AuthenticationResult(
            user.Id,
            user.UserIdentityGuid,
            user.Email,
            user.FirstName,
            user.LastName,
            token
        );
    }
}
