using Bookflix.Domain.Entities;

namespace Bookflix.Application.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}