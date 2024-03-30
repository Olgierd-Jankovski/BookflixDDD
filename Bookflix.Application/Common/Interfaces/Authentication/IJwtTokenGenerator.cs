
using Bookflix.Domain.UserAggregate;

namespace Bookflix.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}