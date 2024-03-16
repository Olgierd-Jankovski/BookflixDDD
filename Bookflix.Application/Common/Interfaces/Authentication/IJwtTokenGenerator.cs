using Bookflix.Domain.Entities;

namespace Bookflix.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}