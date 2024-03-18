using Bookflix.Domain.Entities;

namespace Bookflix.Application.Authentication
{
    public record AuthenticationResult(
        User user,
        string Token
    );
}