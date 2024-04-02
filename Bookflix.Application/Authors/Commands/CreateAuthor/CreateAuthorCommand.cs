using Bookflix.Application.Authors.Common;
using ErrorOr;
using MediatR;

namespace Bookflix.Application.Authors.Commands;

public record CreateAuthorCommand(
    string FirstName,
    string LastName,
    int UserId
) : IRequest<ErrorOr<AuthorResult>>;