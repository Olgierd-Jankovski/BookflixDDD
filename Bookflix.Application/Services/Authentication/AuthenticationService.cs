using Bookflix.Application.Common.Interfaces.Authentication;
using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.Common.Errors;
using Bookflix.Domain.Entities;
using ErrorOr;

namespace Bookflix.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // Check user does not exist
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Check the password is correct
        if(user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Generate jwt token
        var token = _jwtTokenGenerator.GenerateToken(
            user
        );

        return new AuthenticationResult(
            user,
            token
        );
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Check if user does not exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Create user (generate unique ID)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Generate jwt token
        var token = _jwtTokenGenerator.GenerateToken(
            user
        );

        return new AuthenticationResult(
            user,
            token
        );
    }
}