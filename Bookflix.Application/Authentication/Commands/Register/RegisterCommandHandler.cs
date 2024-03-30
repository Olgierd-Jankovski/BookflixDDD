using Bookflix.Application.Common.Interfaces.Authentication;
using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.Common.Errors;
using Bookflix.Domain.UserAggregate;
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
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );


        _userRepository.Add(user);

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
