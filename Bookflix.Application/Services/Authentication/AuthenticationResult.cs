using Bookflix.Domain.Entities;

namespace Bookflix.Application.Services.Authentication
{
    public record AuthenticationResult(
        User user,
        string Token
    );
}