using Bookflix.Application.Authors.Common;
using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Domain.AuthorAggregate;
using Bookflix.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, ErrorOr<AuthorResult>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUserRepository _userRepository;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IUserRepository userRepository)
    {
        _authorRepository = authorRepository;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<AuthorResult>> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetUserById(command.UserId);
        if (user == null)
        {
            return Error.Unauthorized();
        }

        if (user.AuthorId != null)
        {
            return Errors.User.AlreadyRegisteredAsAuthor;
        }

        // if the command is empty, we shall extract the name and surname from the user
        var firstName = string.IsNullOrWhiteSpace(command.FirstName) ? user.FirstName : command.FirstName;
        var lastName = string.IsNullOrWhiteSpace(command.LastName) ? user.LastName : command.LastName;

        var author = Author.Create(firstName, lastName);
        user.SetAuthor(author);

        await _authorRepository.AddAsync(author);
        await _authorRepository.SaveChangesAsync(cancellationToken);

        return new AuthorResult(
            author.Id,
            user.Id,
            author.FirstName,
            author.LastName,
            author.Books.Count,
            author.DateTimeInfo.CreatedDateTime,
            author.DateTimeInfo.UpdatedDateTime
        );
    }
}