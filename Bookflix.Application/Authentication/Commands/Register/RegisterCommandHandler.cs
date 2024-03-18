using Bookflix.Application.Common.Interfaces.Authentication;
using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.Entities;
using Bookflix.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
     IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Check if user does not exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Create user (generate unique ID)
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
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
