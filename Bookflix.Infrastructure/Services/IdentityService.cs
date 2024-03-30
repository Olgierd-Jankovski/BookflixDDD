using System.Security.Claims;
using Bookflix.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Bookflix.Infrastructure.Services
{
    public class IdentityService : IIDentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim != null && int.TryParse(userIdClaim, out var userId))
            {
                return userId;
            }
            return null;
        }
    }
}