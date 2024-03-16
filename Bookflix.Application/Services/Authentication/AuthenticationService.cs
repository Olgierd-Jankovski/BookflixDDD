using Bookflix.Application.Common.Interfaces.Authentication;

namespace Bookflix.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {

        return new AuthenticationResult(
            Guid.NewGuid(),
            "John",
            "Doe",
            email,
            "token"
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists

        // Create user (generate unique ID)

        // Generate token
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(
            userId,
            firstName,
            lastName
        );

        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token
        );
    }
}